using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Chat.Server.Repositories
{
    public class MessageRepository
        : IMessageRepository
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageRepository(IMongoCollection<Message> messages)
        {
            _messages = messages;

            _messages.Indexes.CreateOne(
                new CreateIndexModel<Message>(
                    Builders<Message>.IndexKeys.Ascending(x => x.CorrelationId),
                    new CreateIndexOptions { Unique = false }));

            _messages.Indexes.CreateOne(
                new CreateIndexModel<Message>(
                    Builders<Message>.IndexKeys.Ascending(x => x.SenderId),
                    new CreateIndexOptions { Unique = false }));

            _messages.Indexes.CreateOne(
                new CreateIndexModel<Message>(
                    Builders<Message>.IndexKeys.Ascending(x => x.RecipientId),
                    new CreateIndexOptions { Unique = false }));
        }

        public IQueryable<Message> GetMessages(Guid personId)
        {
            return _messages.AsQueryable();
        }

        public async Task AddMessagesAsync(
            IEnumerable<Message> messages,
            CancellationToken cancellationToken)
        {
            await _messages.InsertManyAsync(
                messages,
                options: default,
                cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task MarkAsReadAsync(
            Guid correlationId, 
            CancellationToken cancellationToken)
        {
            await _messages.UpdateManyAsync(
                Builders<Message>.Filter.Eq(t => t.CorrelationId, correlationId),
                Builders<Message>.Update.Set(t => t.Read, DateTime.UtcNow),
                options: default(UpdateOptions),
                cancellationToken)
                .ConfigureAwait(false);
        }
    }
}