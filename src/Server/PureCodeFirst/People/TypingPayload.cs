using System.Threading;
using System.Threading.Tasks;
using HotChocolate;

namespace Chat.Server.People
{
    public class TypingPayload
    {
        public TypingPayload(Person recipient, string? clientMutationId)
        {
            Recipient = recipient;
            RecipientEmail = recipient.Email;
            ClientMutationId = clientMutationId;
        }

        /// <summary>
        /// The email of the person to which a message is being typed.
        /// </summary>
        public string RecipientEmail { get; }

        /// <summary>
        /// The person to which a message is being typed.
        /// </summary>
        public Person Recipient { get; }

        /// <summary>
        /// The client mutation id which can be optionally provided with a mutation.
        /// </summary>
        public string? ClientMutationId { get; }

        /// <summary>
        /// The email of the person who is typing the message.
        /// </summary>
        public string GetSenderEmail(
            [GlobalState]string currentUserEmail) =>
            currentUserEmail;

        /// <summary>
        /// The person who is typing the message.
        /// </summary>
        public Task<Person> GetSenderAsync(
            [GlobalState]string currentUserEmail,
            PersonByEmailDataLoader personByEmail,
            CancellationToken cancellationToken) =>
            personByEmail.LoadAsync(currentUserEmail, cancellationToken);
    }
}