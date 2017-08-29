using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.Domain.Institution
{
    public class InstitutionsRepository : GenericRepository<InstitutionDb>
    {
        public InstitutionsRepository(AnabiContext ctx) : base(ctx)
        {

        }

    }
}
