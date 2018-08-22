using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Asset.Commands;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class AddAssetAddressHandler : BaseHandler, IAsyncRequestHandler<AddAssetAddress, AddressViewModel>
    {
        public AddAssetAddressHandler(BaseHandlerNeeds needs) : base(needs) {}

        public async Task<AddressViewModel> Handle(AddAssetAddress message)
        {
            var address = new AddressDb()
            {
                CountyId = message.CountyId,
                Street = message.Street,
                City =  message.City,
                Building = message.Building,
                Stair = message.Stair,
                Floor = message.Floor,
                FlatNo = message.FlatNo,
                UserCodeAdd = "pop",
                UserCodeLastChange = message.UserCodeLastChange,
                LastChangeDate = message.AddedDate,
                AddedDate = DateTime.Now
            }; 

            var historicalStageDb = new HistoricalStageDb()
            {
                AddedDate = DateTime.Now,
                UserCodeAdd = "pop",
            };

            context.Addresses.Add(address);
            context.HistoricalStages.Add(historicalStageDb);
            await context.SaveChangesAsync();

            var response = mapper.Map<AddAssetAddress, AddressViewModel>(message);
            response.Id = address.Id;
            response.Journal = new JournalViewModel
            {
                UserCodeAdd = address.UserCodeAdd,
                AddedDate = address.AddedDate,
                UserCodeLastChange = address.UserCodeLastChange,
                LastChangeDate = address.LastChangeDate
            };

            return response;
        }
    } 
}