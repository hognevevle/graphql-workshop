using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Server.Repositories
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetMessages(
            Guid senderId, 
            Guid recipientId);

        Task AddMessageAsync(
            Message message, 
            CancellationToken cancellationToken);
    }
}