using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Server.Repositories
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetMessages(Guid personId);

        Task AddMessagesAsync(
            IEnumerable<Message> messages, 
            CancellationToken cancellationToken);

        Task MarkAsReadAsync(
            Guid correlationId, 
            CancellationToken cancellationToken);
    }
}