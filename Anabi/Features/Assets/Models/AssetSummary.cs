using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Assets.Models
{
    public class AssetSummary
    {
        public int AssetId { get; set; }

        public string AssetName { get; set; }

        public string AssetIdentifier { get; set; }
        public string AssetCategory { get; set; }

        public string AssetSubcategory { get; set; }
        
        public string CurrentStage { get; set; }

        public decimal? EstimatedAmount { get; set; }

        public string EstimatedAmountCurrency { get; set; }

    }
}
