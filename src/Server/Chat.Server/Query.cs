using System;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using Chat.Server.Types;
using HotChocolate;
using HotChocolate.Types;

namespace Chat.Server
{
    public class Query
    {
        [GraphQLType(typeof(NonNullType<ViewerType>))]
        public Task<User> GetMeAsync(
            [State("CurrentUserId")]Guid currentUserId,
            UserByIdDataLoader userByIdDataLoader,
            CancellationToken cancellationToken) =>
            userByIdDataLoader.LoadAsync(currentUserId, cancellationToken);
    }
}
