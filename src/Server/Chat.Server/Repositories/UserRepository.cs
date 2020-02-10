using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Chat.Server.Repositories
{
    public class UserRepository
        : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoCollection<User> users)
        {
            _users = users;
        }

        public Task<User> GetUserByIdAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            return _users.AsQueryable().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyDictionary<Guid, User>> GetUsersByIdsAsync(
            IReadOnlyList<Guid> ids,
            CancellationToken cancellationToken)
        {
            var list = new List<Guid>(ids);

            List<User> result = await _users.AsQueryable()
                .Where(t => list.Contains(t.Id))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return result.ToDictionary(t => t.Id);
        }
    }
}