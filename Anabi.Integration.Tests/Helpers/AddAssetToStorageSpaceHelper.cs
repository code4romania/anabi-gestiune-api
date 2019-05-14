using System;
using System.Net.Http;
using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using Anabi.Domain.Asset.Commands;
using Newtonsoft.Json;

namespace Anabi.Integration.Tests.Helpers
{
    public class AddAssetToStorageSpaceHelper : BaseHelper
    {
        public AddAssetToStorageSpaceHelper(AnabiContext context, HttpClient client) : base(context, client)
        {
        }

        public async Task<AssetStorageSpaceViewModel> AddAssetToStorageSpace(int assetId, int storageSpaceId)
        {
            var msg = new AddAssetToStorageSpaceRequest()
            {
                AssetId = assetId,
                StorageSpaceId = storageSpaceId,
                EntryDate = DateTime.Now
            };

            var response = await Client.PutAsJsonAsync($"api/assets/{assetId}/storagespace/", msg);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var viewModel = JsonConvert.DeserializeObject<AssetStorageSpaceViewModel>(content);
            return viewModel;
        }
    }
}
