using Anabi.Common.ViewModels;
using Anabi.Integration.Tests.Helpers;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Assets.RemoveAssetFromStorageSpace
{
    public class RemoveAssetFromStorageSpaceTest : ApiTests
    {
        public AddMinimalAssetHelper _minimalAssetHelper { get; }
        public AddStorageSpaceHelper _storageSpaceHelper { get; }

        public AddAssetToStorageSpaceHelper _addAssetToStorageSpaceHelper { get; }

        public RemoveAssetFromStorageSpaceTest(AnabiApplicationFactory<Startup> factory) : base(factory)
        {
            Context = new AnabiDbContextBuilder()
                .CreateInMemorySqliteDbContext()
                .WithCounties()
                .WithStages()
                .WithAssetCategories()
                .Build();


            Client = factory.CreateClient();

            _minimalAssetHelper = new AddMinimalAssetHelper(Context, Client);
            _storageSpaceHelper = new AddStorageSpaceHelper(Context, Client);
            _addAssetToStorageSpaceHelper = new AddAssetToStorageSpaceHelper(Context, Client);

        }

        [Fact]
        public async Task RemoveAssetFromStorageSpace_WebResponse_204()
        {
            
            var assetId = await AddMinimalAsset();
            var storageSpaceId = await AddStorageSpace();
            var response = await AddAssetToStorageSpace(assetId, storageSpaceId);

            var combination = Context.AssetStorageSpaces.Single();
            Assert.Equal(response.Id, combination.Id);
            
            var deleteresponse = await Client.DeleteAsync($"api/assets/{assetId}/storagespace/{storageSpaceId}");

            var isDeleted = !Context.AssetStorageSpaces.Any(x => x.AssetId == assetId && x.StorageSpaceId == storageSpaceId);
            Assert.True(isDeleted);
        }


        [Fact]
        public async Task Invalid_AssetId_StorageSpaceId_Combination_BadRequest()
        {
            var fakeId = -1;
            var deleteresponse = await Client.DeleteAsync($"api/assets/{fakeId}/storagespace/{fakeId}");

            Assert.Equal(HttpStatusCode.BadRequest, deleteresponse.StatusCode);
        }

        private Task<AssetStorageSpaceViewModel> AddAssetToStorageSpace(int assetId, int storageSpaceId)
        {
            return _addAssetToStorageSpaceHelper.AddAssetToStorageSpace(assetId, storageSpaceId);
        }

        private Task<int> AddStorageSpace()
        {
            return _storageSpaceHelper.AddStorageSpace();
        }

        private Task<int> AddMinimalAsset()
        {
            return _minimalAssetHelper.AddMinimalAsset();
        }
    }
}
