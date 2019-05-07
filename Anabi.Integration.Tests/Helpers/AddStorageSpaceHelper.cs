using Anabi.DataAccess.Ef;
using Anabi.Domain.StorageSpaces.Commands;
using AutoFixture;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anabi.Integration.Tests.Helpers
{
    public class AddStorageSpaceHelper : BaseHelper
    {
        
        public AddStorageSpaceHelper(AnabiContext context, HttpClient client) : base(context, client)
        {
            
        }

        public async Task<int> AddStorageSpace()
        {
            var msg = Fixture.Build<AddStorageSpace>()
                .With(p => p.CountyCode, "B")
                .Create();

            var response = await Client.PostAsJsonAsync($"api/storagespaces", msg);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsAsync<int>();
            // var assetViewModel = JsonConvert.DeserializeObject<MinimalAssetViewModel>(content);
            return content;
        }
    }
}
