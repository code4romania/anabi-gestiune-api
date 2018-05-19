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
            string personResponsible)
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
    }
}
