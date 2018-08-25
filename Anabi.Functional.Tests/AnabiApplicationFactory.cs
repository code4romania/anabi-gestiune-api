using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Anabi.DataAccess.Ef;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using System.IO;
using Anabi.Domain;
using Anabi.Security;
using MediatR;
using AutoMapper;

namespace Anabi.Functional.Tests
{
    public class AnabiApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            //return base.CreateWebHostBuilder();
            return
                WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:50000")
                .UseEnvironment("Test");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (ApplicationDbContext) using an in-memory 
                // database for testing.
                services.AddDbContext<AnabiContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddMediatR(typeof(Startup), typeof(BaseHandler), typeof(PasswordHashHandler));
                services.AddAutoMapper(typeof(Startup), typeof(BaseHandler));

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AnabiContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<AnabiApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        DbInitializer.Initialize(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the " +
                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}
