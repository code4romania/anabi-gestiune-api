using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
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
            asset.Address = address;

            context.Addresses.Add(address);
            await context.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<AddAssetAddress, AddressViewModel>(message);
            response.Id = address.Id;
            response.Journal = new JournalViewModel
            {
                UserCodeAdd = address.UserCodeAdd,
                AddedDate = address.AddedDate,
            };

            return response;
        }
    } 
}