using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Asset.Commands;
using MediatR;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class AddSolutionHandler : BaseHandler
        , IAsyncRequestHandler<AddSolution, int>
    {
        public AddSolutionHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<int> Handle(AddSolution message)
        {

            var newStage = new HistoricalStageDb
            {
                AssetId = message.AssetId,
                StageId = message.StageId,
                DecizieId = message.DecisionId,
                InstitutionId = message.InstitutionId,
                DecisionDate = message.DecisionDate,
                DecisionNumber = message.DecisionNumber,
                RecoveryBeneficiaryId = message.RecoveryBeneficiaryId,
            };
            
            newStage.ActualValue = message.RecoveryDetails?.ActualAmount;
            newStage.EstimatedAmount = message.RecoveryDetails?.EstimatedAmount;
            newStage.EstimatedAmountCurrency = message.RecoveryDetails?.EstimatedAmountCurrency;
            newStage.ActualValueCurrency = message.RecoveryDetails?.ActualAmountCurrency;
            newStage.RecoveryState = message.RecoveryDetails?.RecoveryState;

            newStage.EvaluationCommittee = message.RecoveryDetails?.EvaluationCommittee?.EvaluationCommitteeMembers;
            newStage.EvaluationCommitteePresident = message.RecoveryDetails?.EvaluationCommittee?.EvaluationCommitteePresident;
            newStage.EvaluationCommitteeDesignationDate = message.RecoveryDetails?.EvaluationCommittee?.EvaluationCommitteeDesignationDate;

            newStage.RecoveryCommittee = message.RecoveryDetails?.RecoveryCommittee?.RecoveryCommitteeMembers;
            newStage.RecoveryCommitteePresident = message.RecoveryDetails?.RecoveryCommittee?.RecoveryCommitteePresident;
            newStage.RecoveryCommitteeDesignationDate = message.RecoveryDetails?.RecoveryCommittee?.RecoveryCommitteeDesignationDate;

            newStage.LastActivity = message.RecoveryDetails?.LastActivity;
            newStage.PersonResponsible = message.RecoveryDetails?.PersonResponsible;

            newStage.Source = message.SolutionDetails?.Source;
            newStage.SentOnEmail = message.SolutionDetails?.SentOnEmail;
            newStage.FileNumber = message.SolutionDetails?.FileNumber;
            newStage.FileNumberParquet = message.SolutionDetails?.FileNumberParquet;
            newStage.ReceivingDate = message.SolutionDetails?.ReceivingDate;
            newStage.IsDefinitive = message.SolutionDetails?.IsDefinitive;
            newStage.DefinitiveDate = message.SolutionDetails?.DefinitiveDate;
            newStage.SendToAuthoritiesDate = message.SolutionDetails?.SentToAuthoritiesDate;
            newStage.CrimeTypeId = message.SolutionDetails?.CrimeTypeId;
            newStage.LegalBasis = message.SolutionDetails?.LegalBasis;

            context.HistoricalStages.Add(newStage);
            await context.SaveChangesAsync();

            return newStage.Id;
        }
    }
}
