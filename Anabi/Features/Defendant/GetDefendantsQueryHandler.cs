using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using Anabi.Domain;
using Anabi.Features.Defendant.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Defendant
{
    public class GetDefendantsQueryHandler : BaseHandler, IAsyncRequestHandler<GetDefendants, List<DefendantViewModel>>
    {

        public GetDefendantsQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<List<DefendantViewModel>> Handle(GetDefendants message)
        {
            var response = await context.AssetDefendants
                .Include(p => p.Person)
                .Where(d => d.AssetId == message.AssetId)
                .Select(r => new DefendantViewModel
                {
                    Id = r.Person.Id,
                    Birthdate = r.Person.Birthdate,
                    FirstName = r.Person.FirstName,
                    Identification = r.Person.Identification,
                    IdentifierId = r.Person.IdentifierId,
                    IdNumber = r.Person.IdNumber,
                    IdSerie = r.Person.IdSerie,
                    IsPerson = r.Person.IsPerson,
                    Journal = new JournalViewModel
                    {
                        AddedDate = r.AddedDate,
                        UserCodeAdd = r.UserCodeAdd,
                        LastChangeDate = r.LastChangeDate,
                        UserCodeLastChange = r.UserCodeLastChange
                    },
                    Name = r.Person.Name,
                    Nationality = r.Person.Nationality
                })
                .ToListAsync();

            return response;
        }
    }
}
