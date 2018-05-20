using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.CrimeTypes.Models
{
    public class GetCrimeTypes : IRequest<List<CrimeType>>
    {
        public int? Id { get; set; }
    }
}
