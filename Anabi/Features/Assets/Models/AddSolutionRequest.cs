using System;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Features.Assets.Models
{
    public class AddSolutionRequest
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

    public class SolutionDetails
    {

        [MaxLength(500)]
        public string Source { get; set; }

        public bool? SentOnEmail { get; set; }

        [MaxLength(200)]
        public string FileNumber { get; set; }

        [MaxLength(200)]
        public string FileNumberParquet { get; set; }


        public DateTime? ReceivingDate { get; set; }


        public bool? IsDefinitive { get; set; }

        public DateTime? DefinitiveDate { get; set; }


        public DateTime? SentToAuthoritiesDate { get; set; }

        

        public int? CrimeTypeId { get; set; }

        public string LegalBasis { get; set; }
    }

    public class RecoveryDetails
    {

        public decimal? ActualValue { get; set; }

        public decimal? EstimatedAmount { get; set; }

        public string EstimatedAmountCurrency { get; set; }

        public string ActualValueCurrency { get; set; }

        public string RecoveryState { get; set; }

        public EvaluationCommittee EvaluationCommittee { get; set; }

        public RecoveryCommittee RecoveryCommittee { get; set; }
        

        public DateTime? LastActivity { get; set; }

        [MaxLength(200)]
        public string PersonResponsible { get; set; }
    }

    public class EvaluationCommittee
    {
        public DateTime? EvaluationCommitteeDesignationDate { get; set; }

        [MaxLength(200)]
        public string EvaluationCommitteePresident { get; set; }

        public string EvaluationCommitteeMembers { get; set; }
    }

    public class RecoveryCommittee
    {
        public DateTime? RecoveryCommitteeDesignationDate { get; set; }

        [MaxLength(200)]
        public string RecoveryCommitteePresident { get; set; }

        public string RecoveryCommitteeMembers { get; set; }
    }
}
