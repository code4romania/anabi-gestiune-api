using Anabi.Common.ViewModels;
using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Features.Assets
{
    public class GetAssetAddressHandler : BaseHandler, IRequestHandler<GetAssetAddress, AddressViewModel>
    {
        public GetAssetAddressHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<AddressViewModel> Handle(GetAssetAddress request, CancellationToken cancellationToken)
        {
            var model = await context.Assets
                .Include(a => a.Address).ThenInclude(c => c.County)
                .Where(r => r.Id == request.AssetId)
                .Select(a => new AddressViewModel
                {
                    Id = a.Address.Id,
                    Building = a.Address.Building,
                    City = a.Address.City,
                    CountyId = a.Address.CountyId,
                    CountyName = a.Address.County.Name,
                    CountyAbreviation = a.Address.County.Abreviation,
                    Description = a.Address.Description,
                    FlatNo = a.Address.FlatNo,
                    Floor = a.Address.Floor,
                    Stair = a.Address.Stair,
                    Street = a.Address.Street,
                    Journal = new JournalViewModel
                    {
                        UserCodeAdd = a.Address.UserCodeAdd,
                        AddedDate = a.Address.AddedDate,
                        LastChangeDate = a.Address.LastChangeDate,
                        UserCodeLastChange = a.Address.UserCodeLastChange
                    }
                })
                .FirstOrDefaultAsync();

            return model;
        }
    }
}
