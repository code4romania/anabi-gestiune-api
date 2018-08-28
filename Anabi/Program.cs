using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Anabi.DataAccess.Ef;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.EntityFrameworkCore;

namespace Anabi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                {
                    var context = services.GetRequiredService<AnabiContext>();
                    logger.LogInformation("Starting migration...");
                    context.Database.Migrate();
                    logger.LogInformation("Migration finished.");
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://*:3000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseStartup<Startup>()             
                .UseApplicationInsights("68fec371-3f13-45b8-ae53-92d0b6a9e18d")
                .Build();
    }
}
