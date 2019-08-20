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
            var result = context.StorageSpaces
                    .Include(x => x.AssetsStorageSpaces)
                    .Include(x => x.Address).ThenInclude(c => c.County)
                .Where(x => x.AssetsStorageSpaces.Any(p => p.AssetId == request.AssetId))
                .Select(sp => new StorageSpaceViewModel()
                {
                    Id = sp.Id,
                    Name = sp.Name,
                    StorageSpaceType = sp.StorageSpacesType,
                    Address = sp.Address != null ? sp.Address.ToStorageSpaceAddressViewModel() : null,
                    Journal = sp.GetJournalViewModel()
                });

            return await result.ToListAsync(cancellationToken);
        }
    }
}
