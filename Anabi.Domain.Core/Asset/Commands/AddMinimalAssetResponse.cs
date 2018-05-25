namespace Anabi.Domain.Asset.Commands
{
    public class AddMinimalAssetResponse : AddMinimalAsset
    {
        public int AssetId { get; set; }

        public int HistoricalStageId { get; set; }
    }
}
