using System;
using System.Collections.Generic;

namespace Anabi.Features.Assets.Models
{
    public class AssetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }

        public string Identifier { get; set; }

        public string Remarks { get; set; }

        public int StageId { get; set; }

        public decimal Quantity { get; set; }

        public string MeasureUnit { get; set; }

        public decimal EstimatedAmount { get; set; }

        public string EstimatedAmountCurrency { get; set; }

        public DateTime AddedDate { get; set; }

        public string UserCodeAdd { get; set; }

        public DateTime? LastChangedDate { get; set; }

        public string UserCodeLastChange { get; set; }

    }
}
