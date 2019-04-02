using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Assets
{
    public class AddSolutionTests : ApiTests
    {
        public AddSolutionTests(AnabiApplicationFactory<Startup> factory) : base(factory)
        {
         
        }

        [Fact]
        public async Task AddSolution_HasRecoveryFields()
        {
            
        }
    }
}
