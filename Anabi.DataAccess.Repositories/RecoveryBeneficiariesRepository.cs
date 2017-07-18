using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Abstractions.Repositories;

namespace Anabi.DataAccess.Repositories
{
    public class RecoveryBeneficiariesRepository : GenericRepository<RecoveryBeneficiaryDb>
    {
        public RecoveryBeneficiariesRepository(AnabiContext ctx) : base(ctx)
        {

        }

    }
}