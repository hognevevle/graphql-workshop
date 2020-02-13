using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using Chat.Server.Repositories;
using HotChocolate;
using HotChocolate.Execution;

namespace Chat.Server
{
    public class Mutation
    {
        public async Task<CreateUserPayload> CreateUser(
            CreateUserInput input,
            [Service]IUserRepository userRepository,
            [Service]IPersonRepository personRepository,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Name))
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage("The name cannot be empty.")
                        .SetCode("USERNAME_EMPTY")
                        .Build());
            }

            if (string.IsNullOrEmpty(input.Email))
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage("The email cannot be empty.")
                        .SetCode("EMAIL_EMPTY")
                        .Build());
            }

            if (string.IsNullOrEmpty(input.Password))
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage("The password cannot be empty.")
                        .SetCode("PASSWORD_EMPTY")
                        .Build());
            }

            string salt = Guid.NewGuid().ToString("N");

            using var sha = SHA512.Create();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input.Password + salt));

            Guid personId = Guid.NewGuid();

            var user = new User(
                Guid.NewGuid(),
                personId,
                input.Email,
                Convert.ToBase64String(hash),
                salt);

            var person = new Person(
                personId,
                user.Id,
                input.Name,
                input.Email,
                DateTime.UtcNow,
                input.Image,
                Array.Empty<Guid>());

            await userRepository.AddUserAsync(
                user, cancellationToken)
                .ConfigureAwait(false);

            await personRepository.AddPersonAsync(
                person, cancellationToken)
                .ConfigureAwait(false);

            return new CreateUserPayload(user, input.ClientMutationId);
        }

        public async Task<InviteFriendPayload> InviteFriendAsync(
            InviteFriendInput input,
            [State("CurrentUserEmail")]string myEmail,
            [DataLoader]PersonByEmailDataLoader personByEmail,
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
                    cancellationToken, input.Email, myEmail)
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

        
            return new InviteFriendPayload(
                people[1].AddFriendId(people[0].Id), 
                input.ClientMutationId);
        }
    }
}
