using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Chat.Server
{
    public class InviteFriendPayload
    {
        public InviteFriendPayload(Person me, string? clientMutationId)
        {
            Me = me;
            ClientMutationId = clientMutationId;
        }

        public Person Me { get; }

        public string? ClientMutationId { get; }
    }

    [ExtendObjectType(Name = "Person")]
    public class PersonExtension
        : INode
    {
    }
}
