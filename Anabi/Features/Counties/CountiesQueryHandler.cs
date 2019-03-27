using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain;
using Anabi.Domain.Models;
using Anabi.Features.Counties.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Counties
{
    public class CountiesQueryHandler : BaseHandler, IRequestHandler<GetCounties, List<County>>
    {
        public CountiesQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public Task<List<County>> Handle(GetCounties message, CancellationToken cancellationToken)
        {
            return context.Counties
                .Select(m => new County
                {
                    Id = m.Id, Name = m.Name, Abreviation = m.Abreviation
                })
                .OrderBy(m => m.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
