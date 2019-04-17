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
    public class AddDefendantTests : ApiTests
    {
        private AddMinimalAssetHelper _addMinimalAssetHelper;
        private Fixture _fixture;

        public AddDefendantTests(AnabiApplicationFactory<Startup> factory) : base(factory)
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
        public async Task AddDefendant_WebResponse_Ok()
        {
            var request = CreateRequest();

            var viewModel = await CreateDefendantWithApi(request);

            Assert.Equal(request.Name, viewModel.Name);
            Assert.Equal(request.FirstName, viewModel.FirstName);
            Assert.Equal(request.Identification, viewModel.Identification);
        }

        [Fact]
        public async Task AddDefendant_DefendantIsRegisteredInDatabase()
        {
            var request = CreateRequest();

            var viewModel = await CreateDefendantWithApi(request);

            var defendant = Context.Persons.Find(viewModel.Id);

            Assert.Equal(request.Name, defendant.Name);
            Assert.Equal(request.FirstName, defendant.FirstName);
            Assert.Equal(request.Identification, defendant.Identification);
        }

        private AddDefendantRequest CreateRequest()
        {
            var identifierId = Context.Identifiers.First().Id;
            var request = _fixture.Build<AddDefendantRequest>()
                .With(x => x.IdentifierId, identifierId)
                .Create();
            return request;
        }

        private async Task<DefendantViewModel> CreateDefendantWithApi(AddDefendantRequest request)
        {
            var assetId = await _addMinimalAssetHelper.AddMinimalAsset();
            

            var json = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync($"api/assets/{assetId}/defendant", stringContent);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var viewModel = JsonConvert.DeserializeObject<DefendantViewModel>(data);
            return viewModel;
        }
    }
}
