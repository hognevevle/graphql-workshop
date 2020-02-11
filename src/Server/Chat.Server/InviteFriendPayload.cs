using Chat.Server.Types;
using HotChocolate;
using HotChocolate.Types;

namespace Chat.Server
{
    public class InviteFriendPayload
    {
        public InviteFriendPayload(User me, string? clientMutationId)
        {
            Me = me;
            ClientMutationId = clientMutationId;
        }

        [GraphQLType(typeof(NonNullType<ViewerType>))]
        public User Me { get; }

        public string? ClientMutationId { get; }
    }
}
