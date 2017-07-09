using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Abstractions.Repositories;

namespace Anabi.DataAccess.Repositories
{
    class StorageSpacesRepository : GenericRepository<StorageSpaceDb>
    {
        public StorageSpacesRepository(AnabiContext ctx) : base(ctx)
        {

        }

    }
}
