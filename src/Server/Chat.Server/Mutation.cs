using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.Repositories;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;

namespace Chat.Server
{
    public class Mutation
    {
        public async Task<CreateUserPayload> CreateUser(
            CreateUserInput input,
            [Service]IUserRepository userRepository,
            [Service]IImageStorage imageStorage,
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

            var user = new User(
                Guid.NewGuid(),
                input.Name,
                input.Email,
                Encoding.UTF8.GetString(hash),
                salt,
                Array.Empty<Guid>());

            await userRepository.CreateUserAsync(
                user, cancellationToken)
                .ConfigureAwait(false);

            await imageStorage.SaveImageAsync(
                user.Id, input.Image, cancellationToken)
                .ConfigureAwait(false);

            return new CreateUserPayload(user, input.ClientMutationId);
        }
    }
}
