using HotChocolate.Types;

namespace Chat.Server.Users
{
    public class CreateUserPayloadType : ObjectType<CreateUserPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateUserPayload> descriptor)
        {
            descriptor.Field(t => t.User).Type<NonNullType<UserType>>();
        }
    }
}