using Anabi.DataAccess.Ef;
using System.Net.Http;
using Xunit;

namespace Anabi.Functional.Tests
{
    public class ApiTests : IClassFixture<AnabiApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public AnabiContext Context { get; set; }

        private readonly AnabiApplicationFactory<Startup> _factory;

        public ApiTests(AnabiApplicationFactory<Startup> factory)
        {
            //Client = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions
            //{
            //    AllowAutoRedirect = false,
            //    BaseAddress = new System.Uri("http://localhost")
            //});
            // new System.Uri("http://localhost:50000/api")
            Client = factory.CreateClient();
            //_factory = factory;
            //var host = factory.Server?.Host;
            //SeedData(host);
        }

        //private void SeedData(IWebHost host)
        //{
        //    if (host == null) { throw new ArgumentNullException("host"); }
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        //        try
        //        {
        //            var db = services.GetRequiredService<AnabiContext>();
        //            db.Database.EnsureCreated();
        //            DbInitializer.Initialize(db);
        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = loggerFactory.CreateLogger<ApiTests>();
        //            logger.LogError(ex, "An error occurred seeding the DB.");
        //        }
        //    }
        //}
    }
}
