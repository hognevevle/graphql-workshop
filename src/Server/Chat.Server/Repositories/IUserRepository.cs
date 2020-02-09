using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Chat.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(
            Guid id,
            CancellationToken cancellationToken);

        Task<IReadOnlyDictionary<Guid, User>> GetUsersByIdsAsync(
            IReadOnlyList<Guid> id, 
            CancellationToken cancellationToken);
    }
}