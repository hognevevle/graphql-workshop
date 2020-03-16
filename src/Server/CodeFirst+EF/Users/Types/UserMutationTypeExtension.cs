using HotChocolate.Types;

namespace Chat.Server.Users
{
    public class UserMutationTypeExtension : ObjectTypeExtension<UserMutations>
    {
        protected override void Configure(IObjectTypeDescriptor<UserMutations> descriptor)
        {
            descriptor.Name("Mutation");

            descriptor.Field(t => t.CreateUserAsync(default!, default!, default))
                .Argument("input", a => a.Type<NonNullType<CreateUserInputType>>())
                .Type<NonNullType<CreateUserPayloadType>>();

            descriptor.Field(t => t.LoginAsync(default!, default!, default!, default!, default))
                .Argument("input", a => a.Type<NonNullType<LoginInputType>>())
                .Type<NonNullType<LoginPayloadType>>();
        }
    }
}