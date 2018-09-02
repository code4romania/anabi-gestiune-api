using Anabi.DataAccess.Ef;
using System.Net.Http;
using Xunit;

namespace Anabi.Functional.Tests
{
    public class ApiTests : IClassFixture<AnabiApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public AnabiContext Context { get; set; }

        public ApiTests(AnabiApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }
        
    }
}
