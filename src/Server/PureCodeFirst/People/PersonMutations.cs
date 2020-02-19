using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using Chat.Server.Repositories;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;

namespace Chat.Server
{
    [ExtendObjectType(Name = "Mutation")]
    public class PersonMutations
    {
        public async Task<InviteFriendPayload> InviteFriendAsync(
            InviteFriendInput input,
            [GlobalState]string currentUserEmail,
            PersonByEmailDataLoader personByEmail,
            [Service]IPersonRepository personRepository,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Email))
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage("The email address cannot be empty.")
                        .SetCode("EMAIL_EMPTY")
                        .Build());
            }

            IReadOnlyList<Person> people =
                await personByEmail.LoadAsync(
                    cancellationToken, input.Email, currentUserEmail)
                    .ConfigureAwait(false);

            if (people[0] is null)
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage("The provided friend email address is invalid.")
                        .SetCode("EMAIL_UNKNOWN")
                        .Build());
            }

            await personRepository.AddFriendIdAsync(
                people[1].Id, people[0].Id, cancellationToken)
                .ConfigureAwait(false);

            await personRepository.AddFriendIdAsync(
                people[0].Id, people[1].Id, cancellationToken)
                .ConfigureAwait(false);

            return new InviteFriendPayload(
                people[1].AddFriendId(people[0].Id),
                input.ClientMutationId);
        }
    }
}