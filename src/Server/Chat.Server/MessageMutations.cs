using System;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using Chat.Server.Repositories;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Language;
using HotChocolate.Types;

namespace Chat.Server
{
    [ExtendObjectType(Name = "Mutation")]
    public class MessageMutations
    {
        public async Task<SendMessagePayload> SendMessageAsync(
            SendMessageInput input,
            FieldNode field,
            [State("CurrentUserEmail")]string email,
            [DataLoader]PersonByEmailDataLoader personByEmail,
            [DataLoader]PersonByIdDataLoader personById,
            [Service]IMessageRepository messageRepository, 
            CancellationToken cancellationToken)
        {
            Person recipient = await personById.LoadAsync(
                input.RecipientId, cancellationToken)
                .ConfigureAwait(false);

            if (recipient is null)
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetCode("UNKNOWN_RECIPIENT")
                        .SetMessage("The given recipient id is invalid.")
                        .AddLocation(field.Arguments[0])
                        .Build());
            }

            Person sender = await personByEmail.LoadAsync(
                email, cancellationToken)
                .ConfigureAwait(false);

            var message = new Message(
                sender.Id,
                recipient.Id,
                input.Text);

            await messageRepository.AddMessageAsync(
                message, cancellationToken)
                .ConfigureAwait(false);

            return new SendMessagePayload(
                sender, 
                recipient, 
                message, 
                input.ClientMutationId);
        }
    }
}
