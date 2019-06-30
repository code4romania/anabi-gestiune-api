using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Search.Models
{
    public class SearchAssetResult
    {
        public int? Id { get; set; }
        public string DefendantName { get; set; }
        public string DecisionNumber { get; set; }
        public string FileNumber { get; set; }
        public string Stage { get; set; }
        public int AssetId { get; set; }

    }
}
