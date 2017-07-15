using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Abstractions.Repositories;

namespace Anabi.DataAccess.Repositories
{
    public class DecisionsRepository : GenericRepository<DecisionDb>
    {
        public DecisionsRepository(AnabiContext ctx) : base(ctx)
        {

        }

    }
}
