using Anabi.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.Asset.Commands.Models
{
    public class RecoveryDetails
    {
        public RecoveryDetails(decimal? actualAmount,
            decimal? estimatedAmount,
            string estimatedAmountCurrency,
            string actualAmountCurrency,
            string recoveryState,
            EvaluationCommittee evaluationCommittee,
            RecoveryCommittee recoveryCommittee,
            DateTime? lastActivity,
            string personResponsible,
            string recoveryApplicationNumber,
            DateTime? recoveryApplicationDate,
            RecoveryDocumentType? recoveryDocumentType,
            string recoveryIssuingInstitution
            )
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

        public EvaluationCommittee EvaluationCommittee { get; }

        public RecoveryCommittee RecoveryCommittee { get; }


        public DateTime? LastActivity { get; }

        [MaxLength(200)]
        public string PersonResponsible { get; }

        [MaxLength(100)]
        public string RecoveryApplicationNumber { get; set; }

        public DateTime? RecoveryApplicationDate { get; set; }

        public RecoveryDocumentType? RecoveryDocumentType { get; set; }

        [MaxLength(200)]
        public string RecoveryIssuingInstitution { get; set; }
    }
}
