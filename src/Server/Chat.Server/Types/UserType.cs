using Chat.Server.DataLoader;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace Chat.Server.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor
                .Name("User")
                .AsNode()
                .IdField(t => t.Id)
                .NodeResolver((ctx, id) =>
                    ctx.DataLoader<UserByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor.Ignore(t => t.FriendIds);
            descriptor.Ignore(t => t.PasswordHash);
            descriptor.Ignore(t => t.Salt);
        }
    }
}
