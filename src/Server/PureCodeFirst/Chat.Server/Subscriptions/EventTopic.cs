using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Chat.Server.Subscriptions
{
    public sealed class EventTopic<TMessage>
        : IDisposable
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly Channel<TMessage> _incoming = Channel.CreateUnbounded<TMessage>();
        private readonly List<Channel<TMessage>> _outgoing = new List<Channel<TMessage>>();
        public event EventHandler<EventArgs> Unsubscribed;

        public EventTopic()
        {
            BeginProcessing();
        }

        public void TryWrite(TMessage message)
        {
            _incoming.Writer.TryWrite(message);
        }

        public ValueTask<InMemoryEventStream<TMessage>> SubscribeAsync(
            CancellationToken cancellationToken)
        {

        }

        private void BeginProcessing()
        {
            Task.Run(async () => await ProcessMessages().ConfigureAwait(false));
        }

        private async Task ProcessMessages()
        {
            await foreach (TMessage message in
                _incoming.Reader.ReadAllAsync().ConfigureAwait(false))
            {
                await _semaphore.WaitAsync().ConfigureAwait(false);

                try
                {
                    ImmutableHashSet<Channel<TMessage>> closedChannel =
                        ImmutableHashSet<Channel<TMessage>>.Empty;

                    for (int i = 0; i < _outgoing.Count; i++)
                    {
                        Channel<TMessage> channel = _outgoing[i];

                        if (!channel.Writer.TryWrite(message)
                            && channel.Reader.Completion.IsCompleted)
                        {
                            closedChannel = closedChannel.Add(channel);
                        }
                    }

                    if (closedChannel.Count > 0)
                    {
                        _outgoing.RemoveAll(c => closedChannel.Contains(c));
                    }

                    if (_outgoing.Count == 0)
                    {
                        RaiseUnsubscribedEvent();
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
            }
        }

        private void RaiseUnsubscribedEvent()
        {
            Task.Run(() => Unsubscribed?.Invoke(this, EventArgs.Empty));
        }

        public void Dispose()
        {
            _semaphore.Wait();

            try
            {
                for (int i = 0; i < _outgoing.Count; i++)
                {
                    _outgoing[i].Writer.TryComplete();;
                }
                _outgoing.Clear();
            }
            finally
            {
                _incoming.Writer.TryComplete();
                _semaphore.Dispose();
            }
        }
    }
}