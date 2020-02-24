using Microsoft.Extensions.DependencyInjection;

namespace Client.Services
{
    public static class ServiceCollectionServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<ITokenStore, TokenStore>();
        }
    }
}