using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.Domain.StorageSpaces
{
    public class StorageSpacesRepository : GenericRepository<StorageSpaceDb>
    {
        public StorageSpacesRepository(AnabiContext ctx) : base(ctx)
        {

        }

    }
}
