using Chat.Server.Types;
using HotChocolate;
using HotChocolate.Types;

namespace Chat.Server
{
    public class CreateUserPayload
    {
        public CreateUserPayload(User user, string? clientMutationId)
        {
            User = user;
            ClientMutationId = clientMutationId;
        }

        [GraphQLType(typeof(NonNullType<UserType>))]
        public User User { get; }

        public string? ClientMutationId { get; }
    }
}
