using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Ef.DbModels.Extensions;
using Anabi.Domain.Asset.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class AssetHandler : BaseHandler
        , IRequestHandler<AddMinimalAsset, MinimalAssetViewModel>
    {
        public AssetHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<MinimalAssetViewModel> Handle(AddMinimalAsset message, CancellationToken cancellationToken)
        {
            var asset = new AssetDb()
            {
                Name = message.Name,
                Description = message.Description,
                Identifier = message.Identifier,
                CategoryId = message.SubcategoryId,
                UserCodeAdd = UserCode(),
                AddedDate = DateTime.Now,
                NrOfObjects = (int)message.Quantity,
                MeasureUnit = message.MeasureUnit,
                Remarks = message.Remarks
            };

            var historicalStageDb = new HistoricalStageDb()
            {
                AddedDate = DateTime.Now,
                StageId = message.StageId,
                UserCodeAdd = UserCode(),
                EstimatedAmount = message.EstimatedAmount,
                EstimatedAmountCurrency = message.EstimatedAmountCurrency
            };

            historicalStageDb.Asset = asset;

            context.Assets.Add(asset);
            context.HistoricalStages.Add(historicalStageDb);
            await context.SaveChangesAsync();

            var response = mapper.Map<AddMinimalAsset, MinimalAssetViewModel>(message);
            response.Id = asset.Id;
            response.StageId = historicalStageDb.StageId;
            response.Journal = asset.GetJournalViewModel();

            return response;

        }
    }
}
