namespace Anabi.Domain.Asset.Commands
{
    public interface IMinimalAsset
    {
        string Name { get; set; }

        string Description { get; set; }

        int SubcategoryId { get; set; }

        string Identifier { get; set; }

        string Remarks { get; set; }

        int StageId { get; set; }

        decimal Quantity { get; set; }

        string MeasureUnit { get; set; }

        decimal EstimatedAmount { get; set; }

        string EstimatedAmountCurrency { get; set; }
    }
}