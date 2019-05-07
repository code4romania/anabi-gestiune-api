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
    public class AddMinimalAssetHelper : BaseHelper
    {
     
        public AddMinimalAssetHelper(AnabiContext context, HttpClient client) : base(context, client)
        {
        }

        public async Task<int> AddMinimalAsset()
        {
            var stage = Context.Stages.First();
            var category = Context.Categories.First();

            var msg = Fixture.Build<AddMinimalAsset>()
                .With(x => x.StageId, stage.Id)
                .With(x => x.SubcategoryId, category.Id)
                .Create();

            var response = await Client.PostAsJsonAsync($"api/assets/addminimalasset", msg);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var assetViewModel = JsonConvert.DeserializeObject<MinimalAssetViewModel>(content);
            return assetViewModel.Id;
        }
    }
}
