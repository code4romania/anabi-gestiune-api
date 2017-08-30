using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Dictionaries.Decision
{
    public class SearchDecision : IRequest<List<Anabi.Domain.Core.Models.Decisions.DecisionSummary>>
    {
        public string DecisionNumber { get; set; }
        public string FileNumber { get; set; }
        // Identification number
        public string PersonID { get; set; }
        public string PersonName { get; set; }
    }
}
