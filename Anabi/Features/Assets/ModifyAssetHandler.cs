using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain;
using Anabi.Domain.Asset.Commands;
using Anabi.Domain.Core.Asset.Commands;
using Anabi.Domain.Models;
using MediatR;

namespace Anabi.Features.Assets
{
    public class ModifyAssetHandler : BaseHandler
        , IAsyncRequestHandler<ModifyMinimalAsset, MinimalAssetViewModel>
    {
        public ModifyAssetHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<MinimalAssetViewModel> Handle(ModifyMinimalAsset message)
        {
            var assetEntity = mapper.Map<ModifyMinimalAsset, AssetDb>(message);
            context.Update(assetEntity);
            await context.SaveChangesAsync();
            var response = mapper.Map<ModifyMinimalAsset, MinimalAssetViewModel>(message);
            return response;
        }
    }
}