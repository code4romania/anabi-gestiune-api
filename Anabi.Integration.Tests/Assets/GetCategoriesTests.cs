using Anabi.Features.Assets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Assets
{
    public class GetCategoriesTests
    {
        [Fact]
        public async Task ParentCategories_ReturnsList()
        {
            var projectRootPath = Path.GetFullPath(Path.Combine(
                                     Directory.GetCurrentDirectory(),
                                     @"..\..\..\..", "Anabi"));

            var hostBuilder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseContentRoot(projectRootPath);
                
            using (var server = new TestServer(hostBuilder))
            {
                var client = server.CreateClient();
                var response = await client.GetAsync("/api/assets/parentcategories");
                response.EnsureSuccessStatusCode();

                var input = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<List<CategoryViewModel>>(input);

                Assert.True(content.Count > 0);

            }
        }

        [Fact]
        public void Subcategories_ReturnsList()
        {
        }
    }
}
