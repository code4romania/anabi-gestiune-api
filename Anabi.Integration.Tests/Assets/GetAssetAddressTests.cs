using Anabi.Common.ViewModels;
using Anabi.Integration.Tests.Helpers;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Assets
{
    public class GetAssetAddressTests : ApiTests
    {
        public AddMinimalAssetHelper _minimalAssetHelper { get; }

        public AddAddressToAssetHelper _addAddressToAssetHelper { get; }

        public GetAssetAddressTests(AnabiApplicationFactory<Startup> factory) : base(factory)
        {
            Context = new AnabiDbContextBuilder()
                .CreateInMemorySqliteDbContext()
                .WithCounties()
                .WithStages()
                .WithAssetCategories()
                .Build();


            Client = factory.CreateClient();

            _minimalAssetHelper = new AddMinimalAssetHelper(Context, Client);
            _addAddressToAssetHelper = new AddAddressToAssetHelper(Context, Client);
        }

        [Fact]
        public async Task GetAssetAddress_ReturnsViewModel()
        {
            var assetId = await AddMinimalAsset();
            var addressModel = await AddAddressToAsset(assetId);

            var response = await Client.GetAsync($"api/assets/{assetId}/address");
            var data = await response.Content.ReadAsStringAsync();
            var viewModel = JsonConvert.DeserializeObject<AddressViewModel>(data);

            Assert.Equal(addressModel.CountyId, viewModel.CountyId);
            Assert.Equal(addressModel.City, viewModel.City);
            Assert.Equal(addressModel.Street, viewModel.Street);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public async Task GetAssetAddress_AssetIdZero_ValidationFail_BadRequest(int assetId)
        {
            var response = await Client.GetAsync($"api/assets/{assetId}/address");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetAssetAddress_AssetIdNotExists_ValidationFail_BadRequest()
        {
            await AddMinimalAsset();
            var id = Context.Assets.Max(a => a.Id) + 1;

            var response = await Client.GetAsync($"api/assets/{id}/address");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private Task<int> AddMinimalAsset()
        {
            return _minimalAssetHelper.AddMinimalAsset();
        }

        private Task<AddressViewModel> AddAddressToAsset(int assetId)
        {
            return _addAddressToAssetHelper.AddAddressToAsset(assetId);
        }
    }
}
