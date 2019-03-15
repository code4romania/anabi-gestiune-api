using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Asset.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class AssetStorageSpaceHandler : BaseHandler,
        IRequestHandler<AddAssetStorageSpace, AssetStorageSpaceViewModel>
    {
        public AssetStorageSpaceHandler(BaseHandlerNeeds needs) : base(needs) { }

        /**
         * Method that handles adding of an asset to a storage space
         **/

        public async Task<AssetStorageSpaceViewModel> Handle(AddAssetStorageSpace message, CancellationToken cancellationToken)
        {
            var assetStorageSpace = new AssetStorageSpaceDb()
            {
                AssetId = message.AssetId,
                StorageSpaceId = message.StorageSpaceId,
                EntryDate = message.EntryDate,
                AddedDate = DateTime.Now,
                UserCodeAdd = UserCode()
            };

            context.AssetStorageSpaces.Add(assetStorageSpace);
            await context.SaveChangesAsync();

            var response = mapper.Map<AddAssetStorageSpace, AssetStorageSpaceViewModel>(message);

            response.Id = assetStorageSpace.Id;
            response.Journal = new JournalViewModel
            {
                UserCodeAdd = UserCode(),
                AddedDate = DateTime.Now
            };

            return response;
        }
    }
}
