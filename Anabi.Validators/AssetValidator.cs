using Anabi.DataAccess.Ef;
using Anabi.Validators.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Validators
{
    public class AssetValidator : IAssetValidator
    {
        private readonly AnabiContext anabiContext;

        public AssetValidator(AnabiContext _anabiContext)
        {
            anabiContext = _anabiContext;
        }

        public async Task<bool> AssetIdExistsInDatabaseAsync(int assetId, CancellationToken arg2)
        {
            if (assetId <= 0)
            {
                return false;
            }
            var exists = await anabiContext.Assets.AnyAsync(x => x.Id == assetId, arg2);
            return exists;
        }
    }
}
