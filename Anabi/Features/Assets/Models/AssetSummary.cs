using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Assets.Models
{
    public class AssetSummary
    {
        public int AssetId { get; set; }
        public string AssetIdentifier { get; set; }
        public string AssetCategory { get; set; }
        public string AssetDescription { get; set; }
        public string FileNumber { get; set; }
        public string Institution { get; set; }
        public string CurrentDecision { get; set; }
        public string CurrentStage { get; set; }
        
    }
}
