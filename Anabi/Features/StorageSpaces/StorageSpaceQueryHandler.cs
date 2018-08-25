using Anabi.Common.Utils;
using Anabi.Domain;
using Anabi.Features.StorageSpaces.Models;
using AutoMapper;
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

            var result = await command.Select(x => Mapper.Map<Models.StorageSpaceViewModel>(x)).ToListAsync(cancellationToken);

            if (result.Count == 0)
            {
                throw new Exception(Constants.NO_STORAGE_SPACES_FOUND);
            }

            return result;

        }

        private IQueryable<DataAccess.Ef.DbModels.StorageSpaceDb> GetCommand(GetStorageSpace message)
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
