using System;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.Asset.Commands.Models
{
    public class RecoveryDetails
    {
        public RecoveryDetails(decimal? actualValue,
            decimal? estimatedAmount,
            string estimatedAmountCurrency,
            string actualValueCurrency,
            string recoveryState,
            EvaluationCommittee evaluationCommittee,
            RecoveryCommittee recoveryCommittee,
            DateTime? lastActivity,
            string personResponsible)
        {
            ActualValue = actualValue;
            EstimatedAmount = estimatedAmount;
            EstimatedAmountCurrency = estimatedAmountCurrency;
            ActualValueCurrency = actualValueCurrency;
            RecoveryState = recoveryState;
            EvaluationCommittee = evaluationCommittee;
            RecoveryCommittee = recoveryCommittee;
            LastActivity = lastActivity;
            PersonResponsible = personResponsible;
        }

        public decimal? ActualValue { get; }

        public decimal? EstimatedAmount { get; }

        public string EstimatedAmountCurrency { get; }

        public string ActualValueCurrency { get; }

        public string RecoveryState { get; }

        public EvaluationCommittee EvaluationCommittee { get; }

        public RecoveryCommittee RecoveryCommittee { get; }


        public DateTime? LastActivity { get; }

        [MaxLength(200)]
        public string PersonResponsible { get; }
    }
}
