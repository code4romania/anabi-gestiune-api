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

        public EvaluationCommitteeViewModel EvaluationCommittee { get; }

        public RecoveryCommitteeViewModel RecoveryCommittee { get; }


        public DateTime? LastActivity { get; }

        public string PersonResponsible { get; }
    }
}
