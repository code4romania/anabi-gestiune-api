using Anabi.DataAccess.Ef;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Functional.Tests.Features.Category
{
    public class CategoriesControllerTests : ApiTests
    {
        public CategoriesControllerTests(AnabiApplicationFactory<Startup> factory) : base(factory)
        {
            var contextBuilder = new AnabiDbContextBuilder();
            Context = contextBuilder
                .CreateInMemoryDbContext()
                .WithAssetCategories()
                .Build();
        }

        [Fact]
        public async Task Get_Categories_ReturnsListWithCategories()
        {
            var response = await Client.GetAsync("api/categories");

            var content = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var model = JsonConvert.DeserializeObject<List<Anabi.Features.Category.Models.Category>>(content);

            Assert.True(model.Count > 0);
        }
    }
}
