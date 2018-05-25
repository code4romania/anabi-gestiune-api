using Anabi.Domain.Models;

namespace Anabi.Domain.Asset.Commands
{
    public class AddMinimalAssetResponse : AddMinimalAsset
    {
        public int AssetId { get; set; }

        public int HistoricalStageId { get; set; }

        public Journal Journal { get; set; }
    }
}
