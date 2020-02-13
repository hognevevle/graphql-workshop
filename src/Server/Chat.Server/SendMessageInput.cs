using System;

namespace Chat.Server
{
    public class SendMessageInput
    {
        public SendMessageInput(
            Guid recipientId,
            string text,
            string? clientMutationId)
        {
            RecipientId = recipientId;
            Text = text;
            ClientMutationId = clientMutationId;
        }

        /// <summary>
        /// The ID of the person to which a message shall be send.
        /// </summary>
        public Guid RecipientId { get; }

        /// <summary>
        /// The message text.
        /// </summary>
        public string Text { get; }

        public string? ClientMutationId { get; }
    }
}
