using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyDictionary<Guid, User>> GetUsersByIdsAsync(
            IReadOnlyList<Guid> ids,
            CancellationToken cancellationToken);

        Task CreateUserAsync(
            User user,
            CancellationToken cancellationToken = default);

        Task UpdatePasswordAsync(
            string userName,
            string newPasswordHash,
            string salt,
            CancellationToken cancellationToken = default);
    }
}