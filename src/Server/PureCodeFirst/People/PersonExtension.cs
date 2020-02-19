using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.Messages;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Chat.Server.People
{
    [ExtendObjectType(Name = "Person")]
    public class PersonExtension
    {
        public bool IsOnline() => true;

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Message>> GetMessagesAsync(
            [GlobalState]string currentUserEmail,
            PersonByEmailDataLoader personByEmail,
            [Parent]Person recipient,
            [Service]IMessageRepository repository,
            CancellationToken cancellationToken)
        {
            Person sender = await personByEmail.LoadAsync(
                currentUserEmail, cancellationToken)
                .ConfigureAwait(false);

            return repository.GetMessages(sender.Id, recipient.Id);
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Person>> GetFriendsAsync(
            [Parent]Person recipient,
            PersonByIdDataLoader personById,
            CancellationToken cancellationToken)
        {
            return await personById.LoadAsync(
                recipient.FriendIds, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
