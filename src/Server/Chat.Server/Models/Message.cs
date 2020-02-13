using System;

namespace Chat.Server
{
    public class Message
    {
        public Message(
            Guid id,
            Guid senderId,
            Guid recipientId,
            Guid correlationId,
            string text)
        {
            Id = id;
            SenderId = senderId;
            RecipientId = recipientId;
            CorrelationId = correlationId;
            Text = text;
        }

        public Guid Id { get; }

        public Guid CorrelationId { get; }

        public Guid SenderId { get; }

        public Guid RecipientId { get; }

        public string Text { get; }
    }
}
