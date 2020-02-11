using System.Threading.Tasks;
using System;
using System.Collections.Immutable;
using Chat.Server.Repositories;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace Chat.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMongoDatabase>(sp => new MongoClient().GetDatabase("chat"));
            services.AddSingleton<IUserRepository>(sp => new UserRepository(sp.GetRequiredService<IMongoDatabase>().GetCollection<User>(nameof(User))));
            services.AddSingleton<IImageStorage, InMemoryImageStorage>();

            services.AddDataLoaderRegistry();

            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType<Query>()
                    .AddMutationType<Mutation>()
                    .EnableRelaySupport());

            services.AddQueryRequestInterceptor((context, builder, ct) => 
            {
                builder.AddProperty("CurrentUserName", "foo");
                return Task.CompletedTask;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphQL();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
