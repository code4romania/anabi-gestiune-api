using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.Domain.RecoveryBeneficiary
{
    public class RecoveryBeneficiariesRepository : GenericRepository<RecoveryBeneficiaryDb>
    {
        public RecoveryBeneficiariesRepository(AnabiContext ctx) : base(ctx)
        {

        }

    }
}