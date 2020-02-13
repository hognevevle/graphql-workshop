using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using Chat.Server.Repositories;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Chat.Server
{
    [ExtendObjectType(Name = "Person")]
    public class PersonExtension
    {
        public bool IsOnline() => true;

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Message>> GetMessages(
            [State("CurrentUserEmail")]string email,
            [DataLoader]PersonByEmailDataLoader personByEmail,
            [Parent]Person recipient,
            [Service]IMessageRepository repository,
            CancellationToken cancellationToken)
        {
            Person sender = await personByEmail.LoadAsync(
                email, cancellationToken)
                .ConfigureAwait(false);

            return repository.GetMessages(sender.Id, recipient.Id);
        }
    }
}
