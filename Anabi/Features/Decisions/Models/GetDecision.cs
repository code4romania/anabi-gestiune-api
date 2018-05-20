using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.Decisions.Models
{
    public class GetDecision : IRequest<List<Decision>>
    {
        public int? Id { get; set; }
    }
}
