using Anabi.Common.Enums;
using System;

namespace Anabi.Common.ViewModels
{
    public class RecoveryDetailsViewModel
    {
        public RecoveryDetailsViewModel(decimal? actualAmount,
            decimal? estimatedAmount,
            string estimatedAmountCurrency,
            string actualAmountCurrency,
            string recoveryState,
            EvaluationCommitteeViewModel evaluationCommittee,
            RecoveryCommitteeViewModel recoveryCommittee,
            DateTime? lastActivity,
            string personResponsible,
            string recoveryApplicationNumber,
            DateTime? recoveryApplicationDate,
            RecoveryDocumentType? recoveryDocumentType,
            string recoveryIssuingInstitution)
        {
            ActualAmount = actualAmount;
            EstimatedAmount = estimatedAmount;
            EstimatedAmountCurrency = estimatedAmountCurrency;
            ActualAmountCurrency = actualAmountCurrency;
            RecoveryState = recoveryState;
            EvaluationCommittee = evaluationCommittee;
            RecoveryCommittee = recoveryCommittee;
            LastActivity = lastActivity;
            PersonResponsible = personResponsible;
            RecoveryApplicationNumber = recoveryApplicationNumber;
            RecoveryApplicationDate = recoveryApplicationDate;
            RecoveryDocumentType = recoveryDocumentType;
            RecoveryIssuingInstitution = recoveryIssuingInstitution;
        }

        public decimal? ActualAmount { get; }

        public decimal? EstimatedAmount { get; }

        public string EstimatedAmountCurrency { get; }

        public string ActualAmountCurrency { get; }

        public string RecoveryState { get; }

        public EvaluationCommitteeViewModel EvaluationCommittee { get; }

        public RecoveryCommitteeViewModel RecoveryCommittee { get; }


        public DateTime? LastActivity { get; }

        public string PersonResponsible { get; }

        public string RecoveryApplicationNumber { get; set; }

        public DateTime? RecoveryApplicationDate { get; set; }

        public RecoveryDocumentType? RecoveryDocumentType { get; set; }

        public string RecoveryIssuingInstitution { get; set; }
    }
}
