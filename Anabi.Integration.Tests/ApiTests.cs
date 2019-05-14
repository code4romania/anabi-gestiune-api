using Anabi.DataAccess.Ef;
using System;
using System.Net.Http;
using Xunit;

namespace Anabi.Integration.Tests
{
    public class ApiTests : IClassFixture<AnabiApplicationFactory<Startup>>
    {
        public HttpClient Client { get; set; }
        public AnabiApplicationFactory<Startup> Factory { get; set; }

        private AnabiContext context;
        public AnabiContext Context
        {
            get { return context; }
            set
            {
                if (Factory.Context == null)
                {
                    context = value;
                    Factory.Context = value;
                }
                else
                {
                    context = Factory.Context;
                }
            }
        }

        public ApiTests(AnabiApplicationFactory<Startup> factory)
        {
            Factory = factory;
        }
    }
}
