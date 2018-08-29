using System;
using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain;
using Anabi.Domain.Asset.Commands;
using Anabi.Domain.Core.Asset.Commands;
using Anabi.Domain.Models;
using MediatR;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Anabi.Features.Assets
{
    public class ModifyAssetHandler : BaseHandler
        , IAsyncRequestHandler<ModifyMinimalAssetObj, MinimalAssetViewModel>
    {
        public ModifyAssetHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<MinimalAssetViewModel> Handle(ModifyMinimalAssetObj assetObj)
        {
            var message = assetObj.ModifyMinimalAsset;
            var id = assetObj.Id;
            var assetEntity = await context.FindAsync<AssetDb>(id);
            
            
            var historicalStageDb = new HistoricalStageDb()
            {
                AddedDate = DateTime.Now,
                StageId = message.StageId,
                UserCodeAdd = "pop",
                EstimatedAmount = message.EstimatedAmount,
                EstimatedAmountCurrency = message.EstimatedAmountCurrency
            };
            historicalStageDb.Asset = assetEntity;
            context.HistoricalStages.Add(historicalStageDb);
            
            var updatedAssetDb = mapper.Map<ModifyMinimalAsset, AssetDb>(message, assetEntity);
            var updatedAssetDto = mapper.Map<AssetDb, ModifyMinimalAsset>(assetEntity);
            context.Update(updatedAssetDb);
            await context.SaveChangesAsync();
            var response = mapper.Map<ModifyMinimalAsset, MinimalAssetViewModel>(updatedAssetDto);
            response.StageId = historicalStageDb.StageId;
            return response;
        }
    }
}