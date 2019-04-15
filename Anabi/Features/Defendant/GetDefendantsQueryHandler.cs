using Anabi.Common.ViewModels;
using Anabi.Domain;
using Anabi.Features.Defendant.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Features.Defendant
{
    public class GetDefendantsQueryHandler : BaseHandler, IRequestHandler<GetDefendants, List<DefendantViewModel>>
    {

        public GetDefendantsQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<List<DefendantViewModel>> Handle(GetDefendants message, CancellationToken cancellationToken)
        {
            var response = await context.AssetDefendants
                .Include(p => p.Defendant)
                .Where(d => d.AssetId == message.AssetId)
                .Select(r => new DefendantViewModel
                {
                    Id = r.Defendant.Id,
                    Birthdate = r.Defendant.Birthdate,
                    FirstName = r.Defendant.FirstName,
                    Identification = r.Defendant.Identification,
                    IdentifierId = r.Defendant.IdentifierId,
                    IdNumber = r.Defendant.IdNumber,
                    IdSerie = r.Defendant.IdSerie,
                    IsPerson = r.Defendant.IsPerson,
                    Journal = new JournalViewModel
                    {
                        AddedDate = r.AddedDate,
                        UserCodeAdd = r.UserCodeAdd,
                        LastChangeDate = r.LastChangeDate,
                        UserCodeLastChange = r.UserCodeLastChange
                    },
                    Name = r.Defendant.Name,
                    Nationality = r.Defendant.Nationality
                })
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}
