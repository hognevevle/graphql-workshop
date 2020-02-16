using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.Subscriptions;
using HotChocolate;
using HotChocolate.Types;

namespace Chat.Server
{
    [ExtendObjectType(Name = "Subscription")]
    public class MessageSubscriptions
    {
        [Subscribe]
        public async ValueTask<IAsyncEnumerable<Message>> OnMessageReceived(
            [GlobalState]string currentUserEmail,
            [Service]IEventSubscription eventSubscription,
            CancellationToken cancellationToken)
        {
            return await eventSubscription.SubscribeAsync<string, Message>(
                currentUserEmail, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
