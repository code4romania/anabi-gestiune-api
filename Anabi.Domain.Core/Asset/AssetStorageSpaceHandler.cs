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
        IRequestHandler<AddAssetStorageSpace, StorageSpaceViewModel>
    {
        public AssetStorageSpaceHandler(BaseHandlerNeeds needs) : base(needs)
        {
            
        }

        public async Task<StorageSpaceViewModel> Handle(AddAssetStorageSpace message, CancellationToken cancellationToken)
        {
            var assetStorageSpace = new AssetStorageSpaceDb()
            {
                StorageSpaceId = message.StorageSpaceId,
                EntryDate = message.EntryDate
            };

            /*var historicalStageDb = new HistoricalStageDb()
            {
                AddedDate = DateTime.Now,
                UserCodeAdd = UserCode(),
            };*/
            context.AssetStorageSpaces.Add(assetStorageSpace);
            await context.SaveChangesAsync();

            var response = mapper.Map<AddAssetStorageSpace, StorageSpaceViewModel>(message);

            response.Id = assetStorageSpace.Id;
            response.Journal = new JournalViewModel
            {

            };

            return response;
        }
    }
}
