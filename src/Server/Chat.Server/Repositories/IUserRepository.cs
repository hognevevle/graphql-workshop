using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Server.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        Task<User> GetUserByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyDictionary<Guid, User>> GetUsersByIdsAsync(
            IReadOnlyList<Guid> ids,
            CancellationToken cancellationToken);

        Task<IReadOnlyDictionary<string, User>> GetUsersByNamesAsync(
            IReadOnlyList<string> names,
            CancellationToken cancellationToken);

        Task CreateUserAsync(
            User user,
            CancellationToken cancellationToken = default);

        Task UpdatePasswordAsync(
            string userName,
            string newPasswordHash,
            string salt,
            CancellationToken cancellationToken = default);

        Task AddFriendIdAsync(
            string userName,
            Guid friendId,
            CancellationToken cancellationToken = default);
    }
}