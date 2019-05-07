using Anabi.Common.ViewModels;
using Anabi.Integration.Tests.Helpers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Assets.RemoveAssetFromStorageSpace
{
    public class RemoveAssetFromStorageSpaceTest : ApiTests
    {
        public AddMinimalAssetHelper _minimalAssetHelper { get; set; }
        public AddStorageSpaceHelper _storageSpaceHelper { get; set; }

        public AddAssetToStorageSpaceHelper _addAssetToStorageSpaceHelper { get; set; }

        public RemoveAssetFromStorageSpaceTest(AnabiApplicationFactory<Startup> factory) : base(factory)
        {
            Context = new AnabiDbContextBuilder()
                .CreateInMemorySqliteDbContext()
                .WithCounties()
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
            await AddAssetToStorageSpace(assetId, storageSpaceId);
        }


        [Fact]
        public async Task Invalid_AssetId_StorageSpaceId_Combination_BadRequest()
        {

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
