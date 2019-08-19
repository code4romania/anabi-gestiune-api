using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anabi.Common.Exceptions;
using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Ef.DbModels.Extensions;
using Anabi.Domain.Common.Address;
using Anabi.Domain.StorageSpaces.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Domain.StorageSpaces
{
    public class StorageSpaceHandler : BaseHandler
        ,IRequestHandler<AddStorageSpace, int>
        ,IRequestHandler<EditStorageSpace, StorageSpaceViewModel>
        ,IRequestHandler<DeleteStorageSpace>
    {
        public StorageSpaceHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<int> Handle(AddStorageSpace message, CancellationToken cancellationToken)
        {
            var newStorageSpace = new StorageSpaceDb()
            {
                Name = message.Name,
                StorageSpacesType = message.StorageSpaceType,
                UserCodeAdd = UserCode(),
                AddedDate = DateTime.Now              
            };
            context.StorageSpaces.Add(newStorageSpace);

            await SetNewAddressToStorageSpace(message, newStorageSpace);
            await context.SaveChangesAsync();

            return newStorageSpace.Id;
        }

        public async Task<StorageSpaceViewModel> Handle(EditStorageSpace message, CancellationToken cancellationToken)
        {

            var storageSpace = await context.StorageSpaces.FindAsync(message.Id);
            ValidateStorageSpace(storageSpace);
            this.mapper.Map(message, storageSpace);
            storageSpace.LastChangeDate = DateTime.Now;
            storageSpace.UserCodeLastChange = UserCode();

            await this.SetNewAddressToStorageSpace(message, storageSpace);
            await context.SaveChangesAsync();

            var responseModel = new StorageSpaceViewModel()
            {
                Id = storageSpace.Id,
                Name = storageSpace.Name,
                Journal = storageSpace.GetJournalViewModel(),
                StorageSpaceType = storageSpace.StorageSpacesType,
                Address = storageSpace.Address.ToStorageSpaceAddressViewModel(),
            };
            return responseModel;

        }

        public async Task<Unit> Handle(DeleteStorageSpace message, CancellationToken cancellationToken)
        {
            var command = context.StorageSpaces.Where(m => m.Id == message.Id).AsQueryable()
                .Include(a => a.Address);

            var storageSpace = await command.FirstOrDefaultAsync();
            ValidateStorageSpace(storageSpace);

            context.StorageSpaces.Remove(storageSpace);

            await context.SaveChangesAsync();
            return Unit.Value;
        }

        private static void ValidateStorageSpace(StorageSpaceDb storageSpace)
        {
            if (storageSpace == null)
            {
                throw new AnabiEntityNotFoundException(Constants.NO_STORAGE_SPACES_FOUND);
            }
        }

        private async Task SetNewAddressToStorageSpace(IAddMinimalAddress message, StorageSpaceDb storageSpace)
        {
            AddressDb address = new AddressDb();
            /*
             * Edit address of a storage space
             */
            if (storageSpace.AddressId > 0)
            {
                address = await this.context.Addresses.FindAsync(storageSpace.AddressId);
                this.mapper.Map(message, address);
                address.LastChangeDate = DateTime.Now;
                address.UserCodeLastChange = UserCode();
            }
            else
            {
                address.City = message.City;
                address.Street = message.Street;
                address.Description = message.Details;
                address.Building = message.Building;
                address.UserCodeAdd = UserCode();
                address.AddedDate = DateTime.Now;
            }

            var countyCode = message.CountyCode.ToUpperInvariant();
            address.County = context.Counties.SingleOrDefault(x => x.Abreviation == countyCode);
            storageSpace.Address = address;
        }
    }
}
