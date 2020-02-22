using Internal;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Client.Extensions;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddHttpClient(
                "ChatClient",
                async (services, client) =>
                {
                    client.BaseAddress = new Uri("http://localhost:5000/");

                    var token = await services
                        .GetRequiredService<ISessionStorageService>()
                        .GetItemAsync<string>("Token");

                    client.AddBearerToken(token);
                });
            builder.Services.AddChatClient();
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
