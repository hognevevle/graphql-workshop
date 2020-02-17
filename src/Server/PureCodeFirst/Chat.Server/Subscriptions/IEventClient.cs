using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Chat.Server.Subscriptions
{
    public interface IEventSubscription
    {
        ValueTask<IEventStream<TMessage>> SubscribeAsync<TTopic, TMessage>(
            TTopic topic,
            CancellationToken cancellationToken = default)
            where TTopic : notnull;
    }

    public interface IEventSender
    {
        ValueTask SendAsync<TTopic, TMessage>(
            TTopic topic,
            TMessage message,
            CancellationToken cancellationToken = default)
            where TTopic : notnull;

        ValueTask CompleteAsync<TTopic>(TTopic topic)
            where TTopic : notnull;
    }

    [Serializable]
    public class InvalidMessageTypeException : Exception
    {
        public InvalidMessageTypeException() { }
        public InvalidMessageTypeException(string message)
            : base(message) { }
        public InvalidMessageTypeException(string message, Exception inner)
            : base(message, inner) { }
        protected InvalidMessageTypeException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }

    public class InMemoryEventHandler
        : IEventSubscription
        , IEventSender
    {
        private readonly ConcurrentDictionary<object, IEventTopic> _topics =
            new ConcurrentDictionary<object, IEventTopic>();

        public ValueTask SendAsync<TTopic, TMessage>(
            TTopic topic,
            TMessage message,
            CancellationToken cancellationToken = default)
            where TTopic : notnull
        {
            IEventTopic eventTopic = _topics.GetOrAdd(topic, s => new EventTopic<TMessage>());

            if (eventTopic is EventTopic<TMessage> et)
            {
                et.TryWrite(message);
                return default;
            }

            throw new InvalidMessageTypeException();
        }

        public async ValueTask CompleteAsync<TTopic>(TTopic topic)
            where TTopic : notnull
        {
            if (_topics.TryGetValue(topic, out IEventTopic? eventTopic))
            {
                await eventTopic.CompleteAsync();
            }
        }

        public async ValueTask<IEventStream<TMessage>> SubscribeAsync<TTopic, TMessage>(
            TTopic topic,
            CancellationToken cancellationToken = default)
            where TTopic : notnull
        {
            IEventTopic eventTopic = _topics.GetOrAdd(topic, s => new EventTopic<TMessage>());

            if (eventTopic is EventTopic<TMessage> et)
            {
                return await et.SubscribeAsync(cancellationToken).ConfigureAwait(false);
            }

            throw new InvalidMessageTypeException();
        }
    }
}