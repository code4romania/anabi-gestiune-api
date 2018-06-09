using System;

namespace Anabi.Common.ViewModels
{
    public class SolutionViewModel : BaseViewModel
    {
        public int StageId { get; set; }

        public int? DecisionId { get; set; }

        public int? InstitutionId { get; set; }

        public DateTime DecisionDate { get; set; }

        public string DecisionNumber { get; set; }

        public int? RecoveryBeneficiaryId { get; set; }

        public RecoveryDetailsViewModel RecoveryDetails { get; set; }

        public SolutionDetailsViewModel SolutionDetails { get; set; }
    }
}
