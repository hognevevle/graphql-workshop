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
            CancellationToken cancellationToken);

        Task<IReadOnlyDictionary<Guid, User>> GetUsersByIdsAsync(
            IReadOnlyList<Guid> ids,
            CancellationToken cancellationToken);
    }
}