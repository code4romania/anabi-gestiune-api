using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Assets
{
    public class GetAssetCategoriesTests : ApiTests
    {

        public GetAssetCategoriesTests(AnabiApplicationFactory<Startup> factory) 
            : base(factory)
        {
            Context = new AnabiDbContextBuilder()
                .CreateInMemoryDbContext()
                .WithAssetCategories()
                .Build();
            
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ParentCategories_ReturnsListWithCategories()
        {
            var response = await Client.GetAsync("api/assets/parentcategories");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<List<Anabi.Features.Category.Models.Category>>(content);

            var categories = Context.Categories.Count(c => c.ParentId == null && c.ForEntity == "bun");

            Assert.Equal(model.Count, categories);
        }

        [Fact]
        public async Task Get_Subcategories_ReturnsListWithCategories()
        {
            var parent = Context.Categories.Where(c => c.ParentId == null && c.ForEntity == "bun").First();

            var response = await Client.GetAsync($"api/assets/subcategories/{parent.Id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<List<Anabi.Features.Category.Models.Category>>(content);

            var categories = Context.Categories.Count(c => c.ParentId == parent.Id);

            Assert.Equal(model.Count, categories);
        }
    }
}
