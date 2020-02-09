using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.Repositories;
using GreenDonut;

namespace Chat.Server.DataLoader
{
    public class UserByIdDataLoader
        : DataLoaderBase<Guid, User>
    {
        private readonly IUserRepository _repository;

        public UserByIdDataLoader(IUserRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<IReadOnlyList<Result<User>>> FetchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            IReadOnlyDictionary<Guid, User> result =
                await _repository.GetUsersByIdsAsync(keys, cancellationToken)
                    .ConfigureAwait(false);

            var users = new Result<User>[keys.Count];

            for (int i = 0; i < keys.Count; i++)
            {
                if (result.TryGetValue(keys[i], out User? user))
                {
                    users[i] = user;
                }
            }

            return users;
        }
    }
}