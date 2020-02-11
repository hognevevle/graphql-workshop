using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace Chat.Server.Types
{
    public class ViewerType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor
                .Name("Viewer")
                .AsNode()
                .IdField(t => t.Id)
                .NodeResolver((ctx, id) =>
                    ctx.DataLoader<UserByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .DefaultIgnores()
                .Field<ViewerResolvers>(t => t.GetFriendsAsync(default!, default!, default))
                .Type<NonNullType<ListType<NonNullType<FriendType>>>>();
        }

        private class ViewerResolvers
        {
            public Task<IReadOnlyList<User>> GetFriendsAsync(
                [Parent]User user,
                [DataLoader]UserByIdDataLoader dataLoader,
                CancellationToken cancellationToken) =>
                dataLoader.LoadAsync(user.FriendIds, cancellationToken);
        }
    }
}
