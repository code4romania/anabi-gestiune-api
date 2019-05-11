using Anabi.DataAccess.Ef;
using AutoFixture;
using System.Net.Http;

namespace Anabi.Integration.Tests.Helpers
{
    public abstract class BaseHelper
    {
        public AnabiContext Context { get; set; }
        public HttpClient Client { get; set; }
        public Fixture Fixture { get; set; }

        public BaseHelper(AnabiContext context, HttpClient client)
        {
            Context = context;
            Client = client;
            Fixture = new Fixture();
        }
    }
}
