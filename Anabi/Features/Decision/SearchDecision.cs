using System.Collections.Generic;
using Anabi.Features.Decision.Models;
using MediatR;

namespace Anabi.Features.Decision
{
    public class SearchDecision : IRequest<List<DecisionSummary>>
    {
        public string DecisionNumber { get; set; }
        public string FileNumber { get; set; }
        // Identification number
        public string PersonID { get; set; }
        public string PersonName { get; set; }
    }
}
