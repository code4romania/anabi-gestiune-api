using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Assets.Models
{
    public class GetCategories : IRequest<List<CategoryViewModel>>
    {
        public bool ParentsOnly { get; set; }

        public int? ParentId { get; set; }
    }
}
