using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using Chat.Server.Types;
using HotChocolate;
using HotChocolate.Types;
using Chat.Server.Repositories;
using HotChocolate.Types.Relay;

namespace Chat.Server
{
    public class Query
    {
        [GraphQLType(typeof(NonNullType<ViewerType>))]
        public Task<User> GetMeAsync(
            [State("CurrentUserName")]string userName,
            [DataLoader]UserByNameDataLoader userByNameDataLoader,
            CancellationToken cancellationToken) =>
            userByNameDataLoader.LoadAsync(userName, cancellationToken);

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLType(typeof(NonNullType<ListType<NonNullType<UserType>>>))]
        public IQueryable<User> GetUsers(
            [Service]IUserRepository userRepository) =>
            userRepository.Users;
            
    }
}
