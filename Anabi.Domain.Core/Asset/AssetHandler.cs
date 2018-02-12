using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Asset.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class AssetHandler : BaseHandler
        , IAsyncRequestHandler<AddMinimalAsset, int>
    {
        public AssetHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task<int> Handle(AddMinimalAsset message)
        {
            var asset = new AssetDb()
            {
                Name = message.Name,
                Description = message.Description,
                Identifier = message.Identifier,
                CategoryId = message.CategoryId,
                UserCodeAdd = "pop",
                AddedDate = DateTime.Now,
                NrOfObjects = (int)message.Quantity,
                MeasureUnit = message.MeasureUnit


            };

            var historicalStageDb = new HistoricalStageDb()
            {
                AddedDate = DateTime.Now,
                StageId = message.StageId,
                UserCodeAdd = "pop",
                EstimatedAmount = message.EstimatedAmount,
                EstimatedAmountCurrency = message.EstimatedAmountCurrency
            };

            historicalStageDb.Asset = asset;

            context.Bunuri.Add(asset);
            context.EtapeIstorice.Add(historicalStageDb);
            await context.SaveChangesAsync();

            return asset.Id;

        }
    }
}
