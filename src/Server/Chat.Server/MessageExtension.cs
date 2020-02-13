using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using HotChocolate;
using HotChocolate.Types;

namespace Chat.Server
{
    [ExtendObjectType(Name = "Message")]
    public class MessageExtension
    {
        public async Task<Direction> GetDirectionAsync(
            [State("CurrentUserEmail")]string email,
            [DataLoader]PersonByEmailDataLoader personByEmail,
            [Parent]Message message,
            CancellationToken cancellationToken)
        {
            Person sender = await personByEmail.LoadAsync(
                email, cancellationToken)
                .ConfigureAwait(false);

            if (message.RecipientId == message.SenderId
                && message.SenderId == sender.Id)
            {
                return Direction.Incoming;
            }

            if (message.SenderId == sender.Id)
            {
                return Direction.Outgoing;
            }

            return Direction.Incoming;
        }
    }
}
