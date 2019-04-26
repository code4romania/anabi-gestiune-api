namespace Anabi.Features.Institution
{
    using MediatR;
    using System.Collections.Generic;

    using Anabi.Features.Institution.Models;
    using System.Threading.Tasks;
    using Anabi.Domain;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;

    public class InstitutionQueryHandler : Domain.BaseHandler, IRequestHandler<GetInstitution, List<Institution>>
    {
       public InstitutionQueryHandler(BaseHandlerNeeds needs) : base(needs) { }

       public async Task<List<Institution>> Handle(GetInstitution message, CancellationToken cancellationToken)
        {
            var result = context.Institutions
                .AsQueryable();
            if (message.Id.HasValue)
            {
                result = result.Where(i => i.Id == message.Id);
            }
                        
            return await result.Select(x=> mapper.Map<Institution>(x)).ToListAsync(cancellationToken);
        }
    }
}
