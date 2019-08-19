using System.Collections.Generic;
using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels.Extensions;

namespace Anabi.Features.Assets
{
    public class GetStorageSpaceAssetHandler : BaseHandler,
        IRequestHandler<GetAssetStorageSpace, List<StorageSpaceViewModel>>
    {
        public GetStorageSpaceAssetHandler(BaseHandlerNeeds needs) : base(needs) { }

        /*
         *  Method that retreives a storage space for a given asset 
         */
        public async Task<List<StorageSpaceViewModel>> Handle( GetAssetStorageSpace request, CancellationToken cancellationToken)
        {

            var result = from storageSpaces in context.StorageSpaces
                join assetStorageSpace in context.AssetStorageSpaces on storageSpaces.Id equals assetStorageSpace
                    .StorageSpaceId
                join asset in context.Assets on assetStorageSpace.AssetId equals asset.Id
                where asset.Id == request.AssetId
                select new StorageSpaceViewModel()
                {
                    Id = storageSpaces.Id,
                    Name = storageSpaces.Name,
                    StorageSpaceType = storageSpaces.StorageSpacesType,
                    Address = storageSpaces.Address.ToStorageSpaceAddressViewModel(),
                    Journal = storageSpaces.GetJournalViewModel()
                };

            return await result.ToListAsync(cancellationToken);
        }
    }
}
