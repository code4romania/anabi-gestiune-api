namespace Anabi.Common.ViewModels
{
    public class MinimalAssetViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int SubcategoryId { get; set; }

        public string Identifier { get; set; }

        public string Remarks { get; set; }

        public int StageId { get; set; }

        public decimal Quantity { get; set; }

        public string MeasureUnit { get; set; }

        public decimal EstimatedAmount { get; set; }

        public string EstimatedAmountCurrency { get; set; }
    }
}
