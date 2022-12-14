using CatalogService.Api.Extensions;
using CatalogService.Api.Infrastructure.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace CatalogService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);

            hostBuilder.MigrateDbContext<CatalogContext>((context, services) =>
            {
                var env = services.GetRequiredService<IWebHostEnvironment>();
                var logger = services.GetRequiredService<ILogger<CatalogContextSeed>>();

                new CatalogContextSeed()
                .SeedAsync(context, env, logger)
                .Wait();

            });

            hostBuilder.Run();

        }

        public static IWebHost CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseDefaultServiceProvider((context, options) =>
            {
                options.ValidateOnBuild = false;
                options.ValidateScopes = false;
            })
            .UseStartup<Startup>()
            .UseWebRoot("Pics")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .Build();
    }
}
