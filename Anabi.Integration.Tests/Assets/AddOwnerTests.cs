using Anabi.Common.ViewModels;
using Anabi.Domain.Person.Commands;
using Anabi.Integration.Tests.Helpers;
using AutoFixture;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Assets
{
    public class AddOwnerTests : ApiTests
    {
        private AddMinimalAssetHelper _addMinimalAssetHelper;
        private Fixture _fixture;

        public AddOwnerTests(AnabiApplicationFactory<Startup> factory) : base(factory)
        {
            Context = new AnabiDbContextBuilder()
                .CreateInMemorySqliteDbContext()
                .WithAllDictionaries()
                .Build();

            Client = factory.CreateClient();

            _addMinimalAssetHelper = new AddMinimalAssetHelper(Context, Client);
            _fixture = new Fixture();
        }


        [Fact]
        public async Task AddOwner_WebResponse_Ok()
        {
            var request = CreateRequest();

            var viewModel = await CreateOwnerWithApi(request);

            Assert.Equal(request.Name, viewModel.Name);
            Assert.Equal(request.FirstName, viewModel.FirstName);
            Assert.Equal(request.Identification, viewModel.Identification);
        }

        [Fact]
        public async Task AddOwner_OwnerIsRegisteredInDatabase()
        {
            var request = CreateRequest();

            var viewModel = await CreateOwnerWithApi(request);

            var owner = Context.Persons.Find(viewModel.Id);

            Assert.Equal(request.Name, owner.Name);
            Assert.Equal(request.FirstName, owner.FirstName);
            Assert.Equal(request.Identification, owner.Identification);
        }

        private AddOwnerRequest CreateRequest()
        {
            var identifierId = Context.Identifiers.First().Id;
            var request = _fixture.Build<AddOwnerRequest>()
                .With(x => x.IdentifierId, identifierId)
                .Create();
            return request;
        }

        private async Task<OwnerViewModel> CreateOwnerWithApi(AddOwnerRequest request)
        {
            var assetId = await _addMinimalAssetHelper.AddMinimalAsset();


            var json = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync($"api/assets/{assetId}/owner", stringContent);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var viewModel = JsonConvert.DeserializeObject<OwnerViewModel>(data);
            return viewModel;
        }
    }
}
