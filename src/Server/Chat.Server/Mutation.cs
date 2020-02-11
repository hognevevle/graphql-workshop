using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using Chat.Server.Repositories;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types.Relay;

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
                Convert.ToBase64String(hash),
                salt,
                Array.Empty<Guid>());

            await userRepository.CreateUserAsync(
                user, cancellationToken)
                .ConfigureAwait(false);

            if (input.Image is { })
            {
                await imageStorage.SaveImageAsync(
                    user.Id, input.Image, cancellationToken)
                    .ConfigureAwait(false);
            }

            return new CreateUserPayload(user, input.ClientMutationId);
        }

        public async Task<InviteFriendPayload> InviteFriendAsync(
            InviteFriendInput input,
            [State("CurrentUserName")]string userName,
            [DataLoader]UserByNameDataLoader userByNameDataLoader,
            [Service]IIdSerializer idSerializer,
            [Service]IUserRepository userRepository,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.UserId))
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage("The user id cannot be empty.")
                        .SetCode("USERID_EMPTY")
                        .Build());
            }

            IdValue value = idSerializer.Deserialize(input.UserId);

            if (!value.TypeName.Equals(nameof(User), StringComparison.Ordinal))
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage("The provided user id has an invalid format.")
                        .SetCode("USERID_INVALID")
                        .Build());
            }

            Guid newFriendId = (Guid)value.Value;

            await userRepository.AddFriendIdAsync(
                userName, newFriendId, cancellationToken)
                .ConfigureAwait(false);

            User user = await userByNameDataLoader.LoadAsync(
                userName, cancellationToken)
                .ConfigureAwait(false);

            return new InviteFriendPayload(user, input.ClientMutationId);
        }
    }
}
