using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Assets.Models
{
    public class SearchAsset : IRequest<List<AssetSummary>>
    {
        //public string DecisionNumber { get; set; }
        //public string FileNumber { get; set; }
        //// Identification number
        //public string PersonID { get; set; }
        //public string PersonName { get; set; }
        //public string AssetDescriptionOrIdentifier { get; set; }
    }
    
}
