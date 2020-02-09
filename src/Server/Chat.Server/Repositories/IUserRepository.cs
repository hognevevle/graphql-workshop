using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Chat.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid id);

        Task<IReadOnlyDictionary<Guid, User>> GetUserAsync(IReadOnlyList<Guid> id);
    }
}