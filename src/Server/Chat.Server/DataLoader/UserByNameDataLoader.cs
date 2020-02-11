using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.Repositories;
using GreenDonut;

namespace Chat.Server.DataLoader
{
    public class UserByNameDataLoader
        : DataLoaderBase<string, User>
    {
        private readonly IUserRepository _repository;

        public UserByNameDataLoader(IUserRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<IReadOnlyList<Result<User>>> FetchAsync(
            IReadOnlyList<string> keys,
            CancellationToken cancellationToken)
        {
            IReadOnlyDictionary<string, User> result =
                await _repository.GetUsersByNamesAsync(keys, cancellationToken)
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