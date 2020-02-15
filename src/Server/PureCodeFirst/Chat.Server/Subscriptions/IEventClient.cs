using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Chat.Server.Subscriptions
{


    public interface IEventSubscription
    {
        IAsyncEnumerable<TMessage> Subscribe<TSession, TMessage>(TSession session)
            where TSession : notnull;
    }

    public interface IEventSender
    {
        ValueTask SendAsync<TSession, TMessage>(
            TSession session,
            TMessage message,
            CancellationToken cancellationToken = default)
            where TSession : notnull;

        ValueTask CompleteAsync<TSession>(TSession session)
            where TSession : notnull;
    }

    public class InMemorySubscription
        : IEventSubscription
        , IEventSender
    {
        private readonly ConcurrentDictionary<object, List<object>> _subscriptions =
            new ConcurrentDictionary<object, List<object>>();

        public async ValueTask SendAsync<TSession, TMessage>(
            TSession session,
            TMessage message,
            CancellationToken cancellationToken = default)
            where TSession : notnull
        {
            List<object> channel = _subscriptions.GetOrAdd(session, s => new List<object>());

            await channel.Writer.WriteAsync(
                message, cancellationToken)
                .ConfigureAwait(false);
        }

        public ValueTask CompleteAsync<TSession>(TSession session)
            where TSession : notnull
        {
            if (_subscriptions.TryRemove(session, out Channel<object?>? channel))
            {
                channel.Writer.TryComplete();
            }
            return default;
        }

        public IAsyncEnumerable<TMessage> Subscribe<TSession, TMessage>(TSession session)
            where TSession : notnull
        {
            Channel<object?> channel = _subscriptions.GetOrAdd(session, s => CreateChannel());



        }

        private InMemoryEventStream<TMessage> CreateEventStream<TMessage>() => null;


    }
}