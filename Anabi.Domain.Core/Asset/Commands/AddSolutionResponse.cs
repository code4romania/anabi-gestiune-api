using System;
using System.Collections.Generic;
using System.Text;
using Anabi.Domain.Asset.Commands.Models;

namespace Anabi.Domain.Asset.Commands
{
    public class AddSolutionResponse : AddSolution
    {
        public AddSolutionResponse(int stageId, int decisionId, int institutionId, DateTime decisionDate, string decisionNumber, int? recoveryBeneficiaryId, RecoveryDetails recoveryDetails, SolutionDetails solutionDetails) : base(stageId, decisionId, institutionId, decisionDate, decisionNumber, recoveryBeneficiaryId, recoveryDetails, solutionDetails)
        {
        }

        public int SolutionId { get; set; }
    }
}
