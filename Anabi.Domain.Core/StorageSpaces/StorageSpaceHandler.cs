using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anabi.Common.Exceptions;
using Anabi.Common.Utils;
using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Common.Address;
using Anabi.Domain.Models;
using Anabi.Domain.StorageSpaces.Commands;
using AutoMapper;
using MediatR;

namespace Anabi.Domain.StorageSpaces
{
    public class StorageSpaceHandler : BaseHandler
        ,IAsyncRequestHandler<AddStorageSpace, int>
        ,IAsyncRequestHandler<EditStorageSpace, StorageSpace>
        ,IAsyncRequestHandler<DeleteStorageSpace>
    {
        public StorageSpaceHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task<int> Handle(AddStorageSpace message)
        {
            var newStorageSpace = new StorageSpaceDb();

            Mapper.Map(message, newStorageSpace);

            context.SpatiiStocare.Add(newStorageSpace);

            await SetNewAddressToStorageSpace(message, newStorageSpace);

            await context.SaveChangesAsync();

            return newStorageSpace.Id;

        }

        public async Task<StorageSpace> Handle(EditStorageSpace message)
        {

            var storageSpace = await context.SpatiiStocare.FindAsync(message.Id);


            if (storageSpace == null)
            {
                throw new AnabiEntityNotFoundException(Constants.NO_STORAGE_SPACES_FOUND);
            }

            this.mapper.Map(message, storageSpace);

            await this.SetNewAddressToStorageSpace(message, storageSpace);

            await context.SaveChangesAsync();


            var responseModel = new StorageSpace();
            this.mapper.Map(storageSpace, responseModel);
            return responseModel;

        }

        public Task Handle(DeleteStorageSpace message)
        {
            throw new NotImplementedException();
        }

        private async Task SetNewAddressToStorageSpace(IAddAddress message, StorageSpaceDb storageSpace)
        {
            AddressDb address;
            if (storageSpace.AddressId > 0)
            {
                address = await this.context.Adrese.FindAsync(storageSpace.AddressId);
                this.mapper.Map(message, address);
            }
            else
            {
                address = this.mapper.Map<IAddAddress, AddressDb>(message);
            }

            var countyCode = message.CountyCode.ToUpperInvariant();
            address.County = context.Judete.SingleOrDefault(x => x.Abreviation == countyCode);
            storageSpace.Address = address;
        }
    }
}
