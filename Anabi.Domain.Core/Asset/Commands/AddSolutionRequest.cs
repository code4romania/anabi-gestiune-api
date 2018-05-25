using Anabi.Domain.Asset.Commands.Models;
using System;

namespace Anabi.Domain.Asset.Commands
{
    public class AddSolutionRequest
    {
        public AddSolutionRequest(int stageId, int decisionId
            , int institutionId, DateTime decisionDate, string decisionNumber,
            int? recoveryBeneficiaryId,
            RecoveryDetails recoveryDetails,
            SolutionDetails solutionDetails)
        {            
            StageId = stageId;
            DecisionId = decisionId;
            InstitutionId = institutionId;
            DecisionDate = decisionDate;
            DecisionNumber = decisionNumber;
            RecoveryBeneficiaryId = recoveryBeneficiaryId;
            RecoveryDetails = recoveryDetails;
            SolutionDetails = solutionDetails;
        }

        

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
