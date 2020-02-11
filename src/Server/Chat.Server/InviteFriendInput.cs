using HotChocolate;
using HotChocolate.Types;

namespace Chat.Server
{
    public class InviteFriendInput
    {
        public InviteFriendInput(string userId, string? clientMutationId)
        {
            UserId = userId;
            ClientMutationId = clientMutationId;
        }

        [GraphQLType(typeof(NonNullType<IdType>))]
        public string UserId { get; }

        public string? ClientMutationId { get; }
    }
}
