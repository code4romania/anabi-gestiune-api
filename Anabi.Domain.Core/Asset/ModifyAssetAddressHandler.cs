using System;
using System.Threading;
using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels.Extensions;
using Anabi.Domain.Core.Asset.Commands;
using MediatR;

namespace Anabi.Domain.Asset
{
    public class ModifyAssetAddressHandler : BaseHandler, IRequestHandler<ModifyAssetAddressModel, AddressViewModel>
    {
        public ModifyAssetAddressHandler(BaseHandlerNeeds needs) : base(needs)
        {

        }

        public async Task <AddressViewModel> Handle(ModifyAssetAddressModel message, CancellationToken cancellationToken)
        {
            var asset = await context.Assets.FindAsync(message.AssetId);

            var address = await context.Addresses.FindAsync(asset.AddressId);

            address.CountyId = message.ModifyAssetAddress.CountyId;
            address.Street = message.ModifyAssetAddress.Street;
            address.City = message.ModifyAssetAddress.City;
            address.Building = message.ModifyAssetAddress.Building;
            address.Description = message.ModifyAssetAddress.Description;
            address.UserCodeLastChange = UserCode();
            address.LastChangeDate = DateTime.Now;

            await context.SaveChangesAsync();

            var response = mapper.Map<ModifyAssetAddressModel, AddressViewModel>(message);
            response.Id = address.Id;
            response.Journal = address.GetJournalViewModel();

            return response;
        }

    }
}