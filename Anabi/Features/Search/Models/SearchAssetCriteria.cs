using Anabi.Features.Assets.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Search.Models
{
    public class SearchAssetCriteria : IRequest<List<SearchAssetResult>>
    {
        public string DecisionNumber { get; set; }
        public string FileNumber { get; set; }
        public string DefendantId { get; set; } //numeric personal code or fiscal unique registrain code
        public string DefendantName { get; set; }

    }
}
