using Anabi.Common.ViewModels;
using Anabi.Domain;
using Anabi.Features.Owner.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Features.Owner
{
    public class GetOwnersQueryHandler : BaseHandler, IRequestHandler<GetOwners, List<OwnerViewModel>>
    {

        public GetOwnersQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<List<OwnerViewModel>> Handle(GetOwners message, CancellationToken cancellationToken)
        {
            var response = await context.AssetOwners
                .Include(p => p.Owner)
                .Where(d => d.AssetId == message.AssetId)
                .Select(r => new OwnerViewModel
                {
                    Id = r.Owner.Id,
                    Birthdate = r.Owner.Birthdate,
                    FirstName = r.Owner.FirstName,
                    Identification = r.Owner.Identification,
                    IdentifierId = r.Owner.IdentifierId,
                    IdNumber = r.Owner.IdNumber,
                    IdSerie = r.Owner.IdSerie,
                    IsPerson = r.Owner.IsPerson,
                    Journal = new JournalViewModel
                    {
                        AddedDate = r.AddedDate,
                        UserCodeAdd = r.UserCodeAdd,
                        LastChangeDate = r.LastChangeDate,
                        UserCodeLastChange = r.UserCodeLastChange
                    },
                    Name = r.Owner.Name,
                    Nationality = r.Owner.Nationality
                })
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}