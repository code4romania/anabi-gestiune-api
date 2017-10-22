namespace Anabi.Features.Institution
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    using Anabi.Features.Institution.Models;
    using System.Threading.Tasks;

    using Microsoft.CodeAnalysis.Diagnostics;
    using Anabi.DataAccess.Ef;
    using Anabi.Domain;

    using AutoMapper;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Anabi.DataAccess.Ef.DbModels;

    public class InstitutionQueryHandler : Domain.BaseHandler, IAsyncRequestHandler<GetInstitution, List<Institution>>
    {
        public InstitutionQueryHandler(AnabiContext _context, IMapper _mapper) : base(_context, _mapper)
        {

        }
       public async Task<List<Institution>> Handle(GetInstitution message)
        {
            var result = context.Institutii
                .Include(nameof(InstitutionDb.Address))
                .AsQueryable();
            if (message.Id.HasValue)
            {
                result = result.Where(i => i.Id == message.Id);
            }
                        
            return await result.Select(x=> mapper.Map<Institution>(x)).ToListAsync();
        }
    }
}
