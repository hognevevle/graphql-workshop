using Microsoft.Extensions.DependencyInjection;
using Chat.Server.Messages;
using Chat.Server.People;
using Chat.Server.Users;
using MongoDB.Driver;

namespace Chat.Server
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            return services
                .AddSingleton<IMongoDatabase>(sp => 
                    new MongoClient().GetDatabase("chat2"))
                .AddSingleton<IUserRepository>(sp => 
                    new UserRepository(sp.GetRequiredService<IMongoDatabase>()
                        .GetCollection<User>(nameof(User))))
                .AddSingleton<IPersonRepository>(sp => 
                    new PersonRepository(sp.GetRequiredService<IMongoDatabase>()
                        .GetCollection<Person>(nameof(Person))))
                .AddSingleton<IMessageRepository>(sp => 
                    new MessageRepository(sp.GetRequiredService<IMongoDatabase>()
                        .GetCollection<Message>(nameof(Message))));
        }
    }
}