using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using Anabi.Domain.Asset.Commands;
using AutoFixture;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anabi.Integration.Tests.Helpers
{
    public class AddMinimalAssetHelper
    {
        private AnabiContext _context;
        private HttpClient _client;
        private Fixture _fixture;

        public AddMinimalAssetHelper(AnabiContext context, HttpClient client)
        {
            _context = context;
            _client = client;
            _fixture = new Fixture();
        }

        public async Task<int> AddMinimalAsset()
        {
            var stage = _context.Stages.First();
            var category = _context.Categories.First();

            var msg = _fixture.Build<AddMinimalAsset>()
                .With(x => x.StageId, stage.Id)
                .With(x => x.SubcategoryId, category.Id)
                .Create();

            var response = await _client.PostAsJsonAsync($"api/assets/addminimalasset", msg);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var assetViewModel = JsonConvert.DeserializeObject<MinimalAssetViewModel>(content);
            return assetViewModel.Id;
        }
    }
}
