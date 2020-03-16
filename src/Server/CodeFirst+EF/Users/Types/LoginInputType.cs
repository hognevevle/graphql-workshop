using HotChocolate.Types;

namespace Chat.Server.Users
{
    public class LoginInputType : InputObjectType<LoginInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<LoginInput> descriptor)
        {
        }
    }
}