using System;
using Anabi.Domain.Asset.Commands.Models;
using Anabi.Domain.Models;

namespace Anabi.Domain.Asset.Commands
{
    public class AddSolutionResponse : BaseModel
    {
        public int StageId { get; set; }

        public int DecisionId { get; set; }

        public int InstitutionId { get; set; }

        public DateTime DecisionDate { get; set; }

        public string DecisionNumber { get; set; }

        public int? RecoveryBeneficiaryId { get; set; }

        public RecoveryDetails RecoveryDetails { get; set; }

        public SolutionDetails SolutionDetails { get; set; }
    }
}
