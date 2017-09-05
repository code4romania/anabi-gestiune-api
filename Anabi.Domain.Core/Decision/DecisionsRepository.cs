using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.Domain.Decision
{
    public class DecisionsRepository : GenericRepository<DecisionDb>
    {
        public DecisionsRepository(AnabiContext ctx) : base(ctx)
        {

        }
    }
}