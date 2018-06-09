using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Validators.Interfaces
{
    public interface IAssetValidator
    {
        Task<bool> AssetIdExistsInDatabaseAsync(int assetId, CancellationToken arg2);
    }
}