using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Asset.Commands;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class AssetHandler : BaseHandler
        , IAsyncRequestHandler<AddMinimalAsset, int>
    {
        public AssetHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<int> Handle(AddMinimalAsset message)
        {
            var asset = new AssetDb()
            {
                Name = message.Name,
                Description = message.Description,
                Identifier = message.Identifier,
                CategoryId = message.SubcategoryId,
                UserCodeAdd = "pop",
                AddedDate = DateTime.Now,
                NrOfObjects = (int)message.Quantity,
                MeasureUnit = message.MeasureUnit,
                Remarks = message.Remarks
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

            context.Assets.Add(asset);
            context.HistoricalStages.Add(historicalStageDb);
            await context.SaveChangesAsync();

            return asset.Id;

        }
    }
}
