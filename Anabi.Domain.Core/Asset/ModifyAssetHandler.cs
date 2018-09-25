using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.Domain.Core.Asset.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Domain.Asset
{
    public class ModifyAssetHandler : BaseHandler
        , IRequestHandler<ModifyMinimalAssetModel, MinimalAssetViewModel>
    {
        public ModifyAssetHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<MinimalAssetViewModel> Handle(ModifyMinimalAssetModel message, CancellationToken cancellationToken)
        {
            var lastHistoricalStage =
                await context.HistoricalStages
                .OrderBy(x => x.Id)
                .LastAsync(a => a.AssetId == message.Id);

            lastHistoricalStage.StageId = message.ModifyMinimalAsset.StageId;
            lastHistoricalStage.UserCodeLastChange = UserCode();
            lastHistoricalStage.LastChangeDate = DateTime.Now;
            lastHistoricalStage.EstimatedAmount = message.ModifyMinimalAsset.EstimatedAmount;
            lastHistoricalStage.EstimatedAmountCurrency = message.ModifyMinimalAsset.EstimatedAmountCurrency;

            var asset = await context.Assets.FindAsync(message.Id);

            asset.Name = message.ModifyMinimalAsset.Name;
            asset.Description = message.ModifyMinimalAsset.Description;
            asset.CategoryId = message.ModifyMinimalAsset.SubcategoryId;
            asset.Identifier = message.ModifyMinimalAsset.Identifier;
            asset.Remarks = message.ModifyMinimalAsset.Remarks;
            asset.NrOfObjects = (int)message.ModifyMinimalAsset.Quantity;
            asset.MeasureUnit = message.ModifyMinimalAsset.MeasureUnit;
            asset.LastChangeDate = DateTime.Now;
            asset.UserCodeLastChange = UserCode();

            await context.SaveChangesAsync();

            var response = new MinimalAssetViewModel()
            {
                Id = asset.Id,
                Description = asset.Description,
                EstimatedAmount = lastHistoricalStage.EstimatedAmount ?? 0,
                EstimatedAmountCurrency = lastHistoricalStage.EstimatedAmountCurrency,
                MeasureUnit = asset.MeasureUnit,
                Quantity = asset.NrOfObjects ?? 0,
                Identifier = asset.Identifier,
                Name = asset.Name,
                Remarks = asset.Remarks,
                StageId = lastHistoricalStage.StageId,
                SubcategoryId = asset.CategoryId,
                Journal = new JournalViewModel
                {
                    UserCodeAdd = asset.UserCodeAdd,
                    AddedDate = asset.AddedDate,
                    LastChangeDate = asset.LastChangeDate,
                    UserCodeLastChange = asset.UserCodeLastChange,
                }
            };
            
            return response;
        }
    }
}