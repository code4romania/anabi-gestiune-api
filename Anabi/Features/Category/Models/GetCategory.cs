using System.Collections.Generic;
using MediatR;

namespace Anabi.Features.Category.Models
{
    public class GetCategory : IRequest<List<Category>>
    {
        public int? Id { get; set; }
    }
}
