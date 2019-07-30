using Anabi.Common.ViewModels;
using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
                .FirstOrDefaultAsync();

            if (model?.Address != null)
            {
                return new AddressViewModel
                {
                    Id = model.Address.Id,
                    Building = model.Address.Building,
                    City = model.Address.City,
                    CountyId = model.Address.CountyId,
                    CountyName = model.Address.County.Name,
                    CountyAbreviation = model.Address.County.Abreviation,
                    Description = model.Address.Description,
                    Street = model.Address.Street,
                    Journal = new JournalViewModel
                    {
                        UserCodeAdd = model.Address.UserCodeAdd,
                        AddedDate = model.Address.AddedDate,
                        LastChangeDate = model.Address.LastChangeDate,
                        UserCodeLastChange = model.Address.UserCodeLastChange
                    }
                };
            }
            else
            {
                return new AddressViewModel();
            }  
        }
    }
}
