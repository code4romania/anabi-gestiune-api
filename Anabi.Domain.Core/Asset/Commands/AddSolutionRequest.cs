using Anabi.Domain.Asset.Commands.Models;
using System;

namespace Anabi.Domain.Asset.Commands
{
    public class AddSolutionRequest
    {
        public AddSolutionRequest(int stageId, int decisionId
            , int institutionId, DateTime decisionDate, string decisionNumber,
            ConfiscationDetails confiscationDetails,
            RecoveryDetails recoveryDetails,
            SolutionDetails solutionDetails, 
            SequesterDetails sequesterDetails)
        {            
            StageId = stageId;
            DecisionId = decisionId;
            InstitutionId = institutionId;
            DecisionDate = decisionDate;
            DecisionNumber = decisionNumber;
            ConfiscationDetails = confiscationDetails;
            RecoveryDetails = recoveryDetails;
            SolutionDetails = solutionDetails;
            SequesterDetails = sequesterDetails;
        }

        

        public int StageId { get; }

        public int DecisionId { get; }

        public int InstitutionId { get; }

        public DateTime DecisionDate { get; }

        public string DecisionNumber { get; }

        public ConfiscationDetails ConfiscationDetails { get; }


        public RecoveryDetails RecoveryDetails { get; }

        public SolutionDetails SolutionDetails { get; }

        public SequesterDetails SequesterDetails { get; }

    }
}
