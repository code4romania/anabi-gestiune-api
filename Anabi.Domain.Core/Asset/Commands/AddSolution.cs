using Anabi.Domain.Asset.Commands.Models;
using MediatR;
using System;

namespace Anabi.Domain.Asset.Commands
{
    public class AddSolution : IRequest<int>
    {
        public AddSolution(int assetId, int stageId, int decisionId
            ,int institutionId, DateTime decisionDate, string decisionNumber,
            int? recoveryBeneficiaryId,
            RecoveryDetails recoveryDetails,
            SolutionDetails solutionDetails)
        {
            AssetId = assetId;
            StageId = stageId;
            DecisionId = decisionId;
            InstitutionId = institutionId;
            DecisionDate = decisionDate;
            DecisionNumber = decisionNumber;
            RecoveryBeneficiaryId = recoveryBeneficiaryId;
            RecoveryDetails = recoveryDetails;
            SolutionDetails = solutionDetails;
        }

        public int AssetId { get; }

        public int StageId { get; }

        public int DecisionId { get; }

        public int InstitutionId { get; }

        public DateTime DecisionDate { get; }

        public string DecisionNumber { get; }

        public int? RecoveryBeneficiaryId { get; }

        public RecoveryDetails RecoveryDetails { get; }

        public SolutionDetails SolutionDetails { get; }
    }
}
