using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Anabi.DataAccess.Ef;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;

namespace Anabi.Integration.Tests
{
    public class AnabiApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        public AnabiContext Context { get; set; }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
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
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddSingleton(Context);
            });
        }

        protected override void Dispose(bool disposing)
        {
            Context?.Dispose();
            base.Dispose(disposing);
        }
    }
}
