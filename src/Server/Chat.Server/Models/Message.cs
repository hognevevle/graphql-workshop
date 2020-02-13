using System;

namespace Chat.Server
{
    public class Message
    {
        public Message(
            Guid id,
            Guid senderId,
            Guid recipientId,
            Direction direction,
            string text,
            DateTime sent,
            DateTime read)
        {
            Id = id;
            SenderId = senderId;
            RecipientId = recipientId;
            Direction = direction;
            Text = text;
            Sent = sent;
            Read = read;
        }

        public Guid Id { get; }

        public Guid CorrelationId { get; }

        public Guid SenderId { get; }

        public Guid RecipientId { get; }

        public Direction Direction { get; }

        public string Text { get; }

        public DateTime Sent { get; }

        public DateTime? Read { get; }
    }
}
