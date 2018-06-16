namespace Anabi.Common.ViewModels
{
    public class ConfiscationDetailsViewModel
    {
        public ConfiscationDetailsViewModel(int? recoveryBeneficiaryId)
        {
            RecoveryBeneficiaryId = recoveryBeneficiaryId;
        }
        public int? RecoveryBeneficiaryId { get; }
    }
}