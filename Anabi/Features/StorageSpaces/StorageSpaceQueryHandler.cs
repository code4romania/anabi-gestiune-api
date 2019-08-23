using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Ef.DbModels.Extensions;
using Anabi.Domain;
using Anabi.Features.StorageSpaces.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Features.StorageSpaces
{
    public class StorageSpaceQueryHandler : BaseHandler, IRequestHandler<GetStorageSpace, List<StorageSpaceViewModel>>
    {
        public StorageSpaceQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {

        }

        public async Task<List<StorageSpaceViewModel>> Handle(GetStorageSpace message, CancellationToken cancellationToken)
        {
            if (message.Id != null && message.Id <= 0)
            {
                throw new Exception(Constants.INVALID_ID);
            }

            var command = GetCommand(message);

            var command2 = command.Select(storageSpace => new StorageSpaceViewModel
            {
                Id = storageSpace.Id,
                Name = storageSpace.Name,
                StorageSpaceType = storageSpace.StorageSpacesType,
                Address = storageSpace.Address.ToStorageSpaceAddressViewModel(),
                Journal = storageSpace.GetJournalViewModel()
            });

            var result = await command2.ToListAsync(cancellationToken);
            return result;
        }

        private IQueryable<StorageSpaceDb> GetCommand(GetStorageSpace message)
        {
            IQueryable<StorageSpaceDb> command = context.StorageSpaces
                .Include(a => a.Address).ThenInclude(x => x.County);

            if (message.Id.HasValue && message.Id > 0)
            {
                command = command.Where(x => x.AssetsStorageSpaces.Any(c => c.AssetId == message.Id));
            }
                
            return command;
        }
    }
}
