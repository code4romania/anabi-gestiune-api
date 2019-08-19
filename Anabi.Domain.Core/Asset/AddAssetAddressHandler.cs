using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Ef.DbModels.Extensions;
using Anabi.Domain.Asset.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class AddAssetAddressHandler : BaseHandler, IRequestHandler<AddAssetAddress, AddressViewModel>
    {
        public AddAssetAddressHandler(BaseHandlerNeeds needs) : base(needs) {}

        public async Task<AddressViewModel> Handle(AddAssetAddress message, CancellationToken cancellationToken)
        {
            var address = new AddressDb()
            {
                CountyId = message.CountyId,
                Street = message.Street,
                City =  message.City,
                Building = message.Building,
                Description = message.Description,
                UserCodeAdd = UserCode(),
                AddedDate = DateTime.Now
            }; 

            var asset = await context.Assets.FindAsync(message.AssetId);
            var county = await context.Counties.FindAsync(message.CountyId);

            asset.Address = address;

            context.Addresses.Add(address);
            await context.SaveChangesAsync(cancellationToken);

            return address.ToAddressViewModel();
        }
    } 
}