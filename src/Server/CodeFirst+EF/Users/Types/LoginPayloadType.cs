using Chat.Server.People;
using HotChocolate.Types;

namespace Chat.Server.Users
{
    public class LoginPayloadType : ObjectType<LoginPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<LoginPayload> descriptor)
        {
            descriptor.Field(t => t.Me).Type<NonNullType<PersonType>>();
        }
    }
}