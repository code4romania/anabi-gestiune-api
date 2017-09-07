using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.Decision.Models
{
    public class GetDecisionDetails : IRequest<List<DecisionDetails>>
    {
        public int? Id { get; set; }
    }
    
}
