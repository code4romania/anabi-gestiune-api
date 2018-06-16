namespace Anabi.Domain.Asset.Commands.Models
{
    public class ConfiscationDetails
    {
        public ConfiscationDetails(int? recoveryBeneficiaryId)
        {
            RecoveryBeneficiaryId = recoveryBeneficiaryId;
        }
        public int? RecoveryBeneficiaryId { get; }
    }
}
