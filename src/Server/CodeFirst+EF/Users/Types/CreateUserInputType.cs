using HotChocolate.Types;

namespace Chat.Server.Users
{
    public class CreateUserInputType : InputObjectType<CreateUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateUserInput> descriptor)
        {
        }
    }
}