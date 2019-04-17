using Anabi.Common.Enums;
using Anabi.Common.ViewModels;
using Anabi.Domain.Asset.Commands;
using Anabi.Integration.Tests.Helpers;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Assets
{
    public class AddSolutionTests : ApiTests
    {
        private AddMinimalAssetHelper _addMinimalAssetHelper;

        public AddSolutionTests(AnabiApplicationFactory<Startup> factory) : base(factory)
        {
            Context = new AnabiDbContextBuilder()
                .CreateInMemorySqliteDbContext()
                .WithAllDictionaries()
                .Build();

            Client = factory.CreateClient();

            _addMinimalAssetHelper = new AddMinimalAssetHelper(Context, Client);
            
        }

        [Fact]
        public async Task AddSolution_HasRecoveryFields()
        {
            var assetId = await _addMinimalAssetHelper.AddMinimalAsset();

            var applicationNr = "aa232";
            var applicationDate = DateTime.Today;
            var recoveryDocType = RecoveryDocumentType.Ordonanta;
            var issuingInstitution = "institution A";
            var request = CreateSolutionRequest(applicationNr, applicationDate, recoveryDocType, issuingInstitution);

            var json = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync($"api/assets/{assetId}/solutions", stringContent);

            var data = await response.Content.ReadAsStringAsync();
            var viewModel = JsonConvert.DeserializeObject<SolutionViewModel>(data);

            var solution = Context.HistoricalStages.Find(viewModel.Id);

            Assert.Equal(applicationNr, solution.RecoveryApplicationNumber);
            Assert.Equal(applicationDate, solution.RecoveryApplicationDate);
            Assert.Equal(recoveryDocType, solution.RecoveryDocumentType);
            Assert.Equal(issuingInstitution, solution.RecoveryIssuingInstitution);
        }

        

        private AddSolutionRequest CreateSolutionRequest(string applicationNr, DateTime applicationDate, RecoveryDocumentType recoveryDocumentType, string issuingInstitution)
        {
            var stage = Context.Stages.First();
            var decision = Context.Decisions.First();
            var institution = Context.Institutions.First();

            return new AddSolutionRequest(
                stageId: stage.Id,
                decisionId: decision.Id,
                institutionId: institution.Id,
                decisionDate: DateTime.Today,
                decisionNumber: "aa123",
                confiscationDetails: null,
                recoveryDetails: new Domain.Asset.Commands.Models.RecoveryDetails(actualAmount: 1000,
                    estimatedAmount: 2000, estimatedAmountCurrency: "RON", actualAmountCurrency: "RON", recoveryState: "ok",
                    evaluationCommittee: new Domain.Asset.Commands.Models.EvaluationCommittee(evaluationCommitteeDesignationDate: DateTime.Today, evaluationCommitteePresident: "P", evaluationCommitteeMembers: "A,B"),
                    recoveryCommittee: new Domain.Asset.Commands.Models.RecoveryCommittee(recoveryCommitteeDesignationDate: DateTime.Now, recoveryCommitteePresident: "P", recoveryCommitteeMembers: "A,B"),
                    lastActivity: DateTime.Now, personResponsible: "Alex",
                    recoveryApplicationNumber: applicationNr,
                    recoveryApplicationDate: applicationDate,
                    recoveryDocumentType: recoveryDocumentType,
                    recoveryIssuingInstitution: issuingInstitution),
                solutionDetails: null,
                sequesterDetails: null
                );
        }
    }
}
