using Anabi.Common.Exceptions;
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
            var address = await context.Assets
                .Where(r => r.Id == request.AssetId)
                .Select(a => a.Address)
                .FirstOrDefaultAsync();

            if(address == null)
            {
                throw new AnabiEntityNotFoundException("NO_ADDRESS_FOUND");
            }

            return new AddressViewModel
            {
                Id = address.Id,
                Building = address.Building,
                City = address.City,
                CountyId = address.CountyId,
                CountyName = address.County.Name,
                CountyAbreviation = address.County.Abreviation,
                Description = address.Description,
                Street = address.Street,
                Journal = new JournalViewModel
                {
                    UserCodeAdd = address.UserCodeAdd,
                    AddedDate = address.AddedDate,
                    LastChangeDate = address.LastChangeDate,
                    UserCodeLastChange = address.UserCodeLastChange
                }
            };
        }
    }
}
