using Anabi.Features.Decision.Models;
using System.Collections.Generic;

namespace Anabi.Features.Assets.Models
{
    public class AssetDetails
    {
        public List<DecisionDetails> Decisions { get; set; }

        public Asset Asset { get; set; }

        public List<File> Files { get; set; }
    }
}
