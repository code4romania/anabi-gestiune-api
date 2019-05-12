using System.Collections.Generic;
using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anabi.Common.Exceptions;
using System.Threading;
using Anabi.Domain.Models;
using Anabi.Features.StorageSpaces.Models;
using Anabi.Common.ViewModels;

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
                    Addresss = new Domain.Models.Address()
                    {
                        Id = storageSpaces.AddressId,
                        County = new County()
                        {
                            Id = storageSpaces.Address.CountyId,
                            Abreviation = storageSpaces.Address.County.Abreviation,
                            Name = storageSpaces.Address.County.Name
                        },
                        City = storageSpaces.Address.City,
                        Street = storageSpaces.Address.Street,
                        Building = storageSpaces.Address.Building
                    },
                    Journal = new JournalViewModel
                    {
                        UserCodeAdd = storageSpaces.UserCodeAdd,
                        AddedDate = storageSpaces.AddedDate,
                        UserCodeLastChange = storageSpaces.UserCodeLastChange,
                        LastChangeDate = storageSpaces.LastChangeDate
                    }
                };

            if (!result.Any())
            {
                throw new AnabiEntityNotFoundException("STORAGE_SPACE_CANNOT_BE_FOUND");
            }

            return await result.ToListAsync(cancellationToken);
        }
    }
}
