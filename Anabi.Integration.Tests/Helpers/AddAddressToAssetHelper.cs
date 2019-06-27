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
    public class AddAddressToAssetHelper : BaseHelper
    {
        public AddAddressToAssetHelper(AnabiContext context, HttpClient client) : base(context, client)
        {
        }

        public async Task<AddressViewModel> AddAddressToAsset(int assetId)
        {
            var countyId = Context.Counties.First().Id;

            var msg = new AddAssetAddressRequest(countyId, "street 1", "Buc", "cladire", "descriere");

            var response = await Client.PostAsJsonAsync($"api/assets/{assetId}/address", msg);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var assetViewModel = JsonConvert.DeserializeObject<AddressViewModel>(content);
            return assetViewModel;
        }
    }
}
