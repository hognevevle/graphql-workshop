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
            services.AddSingleton<IMongoDatabase>(sp => new MongoClient().GetDatabase("chat2"));
            services.AddSingleton<IUserRepository>(sp => new UserRepository(sp.GetRequiredService<IMongoDatabase>().GetCollection<User>(nameof(User))));
            services.AddSingleton<IPersonRepository>(sp => new PersonRepository(sp.GetRequiredService<IMongoDatabase>().GetCollection<Person>(nameof(Person))));
            services.AddSingleton<IMessageRepository>(sp => new MessageRepository(sp.GetRequiredService<IMongoDatabase>().GetCollection<Message>(nameof(Message))));
            services.AddSingleton<IImageStorage, InMemoryImageStorage>();

            services.AddDataLoaderRegistry();

            services.AddCors();

            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType<Query>()
                    .AddMutationType<Mutation>());

            services.AddQueryRequestInterceptor((context, builder, ct) =>
            {
                builder.AddProperty("CurrentUserEmail", "foo@bar.com");
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

            app.UseCors(o => o
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

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
