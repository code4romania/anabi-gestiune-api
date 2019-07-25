using Anabi.Common.Utils;
using Anabi.DataAccess.Ef.DbModels;
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
    public class StorageSpaceQueryHandler : BaseHandler, IRequestHandler<GetStorageSpace, List<Models.StorageSpaceViewModel>>
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
            
            var result = await command.Select(storageSpace => new StorageSpaceViewModel
            {
                Id = storageSpace.Id,
                Name = storageSpace.Name,
                StorageSpaceType = storageSpace.StorageSpacesType,                
                Address = new Domain.Models.Address()
                {
                    Id = storageSpace.AddressId,
                    County = new Domain.Models.County()
                    {
                        Id = storageSpace.Address.CountyId,
                        Abreviation = storageSpace.Address.County.Abreviation,
                        Name = storageSpace.Address.County.Name
                    },
                    City = storageSpace.Address.City,
                    Street = storageSpace.Address.Street,
                    Building = storageSpace.Address.Building               
                }
            }).ToListAsync(cancellationToken);
            
            return result;
        }

        private IQueryable<StorageSpaceDb> GetCommand(GetStorageSpace message)
        {
            var command = context.StorageSpaces.AsQueryable();
            if (message.Id != null)
            {
                command = command.Where(m => m.Id == message.Id);
            }
            command = command.Include(a => a.Address);
            return command;
        }
    }
}
