using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain;
using Anabi.Domain.Core.Asset.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Assets
{
    public class ModifyAssetHandler : BaseHandler
        , IRequestHandler<ModifyMinimalAssetObj, MinimalAssetViewModel>
    {
        public ModifyAssetHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<MinimalAssetViewModel> Handle(ModifyMinimalAssetObj assetObj, CancellationToken cancellationToken)
        {
            var message = assetObj.ModifyMinimalAsset;
            var id = assetObj.Id;

            var assetEntity =
                await context.Assets.Include(a => a.HistoricalStages).FirstOrDefaultAsync(a => a.Id == id);
            assetEntity.HistoricalStages.Where(hs => hs.AssetId == id).Select(hs =>
            {
                hs.StageId = message.StageId;
                hs.UserCodeAdd = UserCode();
                hs.EstimatedAmount = message.EstimatedAmount;
                hs.EstimatedAmountCurrency = message.EstimatedAmountCurrency;
                return hs;
            });

            var updatedAssetDb = mapper.Map<ModifyMinimalAsset, AssetDb>(message, assetEntity);
            var updatedAssetDto = mapper.Map<AssetDb, ModifyMinimalAsset>(assetEntity);
            context.Update(updatedAssetDb);
            await context.SaveChangesAsync();
            var response = mapper.Map<ModifyMinimalAsset, MinimalAssetViewModel>(updatedAssetDto);
            response.StageId = message.StageId;
            return response;
        }
    }
}