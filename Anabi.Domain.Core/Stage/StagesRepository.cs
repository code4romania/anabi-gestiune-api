using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.Domain.Stage
{
    public class StagesRepository : GenericRepository<StageDb>
    {
        public StagesRepository(AnabiContext ctx) : base(ctx)
        {

        }

    }
}
