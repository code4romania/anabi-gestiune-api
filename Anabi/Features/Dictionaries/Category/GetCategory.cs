using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Domain.Core.Models;

namespace Anabi.Features.Dictionaries.Category
{
    public class GetCategory : IRequest<List<Anabi.Domain.Core.Models.Category>>
    {
        public int? Id { get; set; }
    }
}
