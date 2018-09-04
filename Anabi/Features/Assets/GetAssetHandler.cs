using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anabi.Common.Exceptions;
using Anabi.Common.ViewModels;
using System.Threading;

namespace Anabi.Features.Assets
{
    public class GetAssetHandler : BaseHandler, IRequestHandler<GetAssetDetails, MinimalAssetViewModel>
    {
        public GetAssetHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<MinimalAssetViewModel> Handle(GetAssetDetails message, CancellationToken cancellationToken)
        {

            var asset = await (from a in context.Assets

                               //last stage of the asset
                               from historicalStage in context.HistoricalStages
                                        .Where(x => x.AssetId == a.Id)
                                        .OrderByDescending(x => x.Id)
                                        .Take(1)
                               where a.Id == message.Id
                         select new MinimalAssetViewModel()
                         {
                             SubcategoryId = a.CategoryId,
                             Description = a.Description,
                             EstimatedAmount = (historicalStage.EstimatedAmount ?? 0),
                             EstimatedAmountCurrency = historicalStage.EstimatedAmountCurrency,
                             Id = a.Id,
                             Identifier = a.Identifier,
                             MeasureUnit = a.MeasureUnit,
                             Name = a.Name,
                             Remarks = a.Remarks,
                             Quantity = (a.NrOfObjects ?? 0),
                             StageId = historicalStage.StageId,
                             Journal = new JournalViewModel
                             {
                                 UserCodeAdd = a.UserCodeAdd,
                                 AddedDate = a.AddedDate,
                                 UserCodeLastChange = a.UserCodeLastChange,
                                 LastChangeDate = a.LastChangeDate
                             },
                         })
                         .FirstOrDefaultAsync(cancellationToken);

            if (asset == null)
            {
                throw new AnabiEntityNotFoundException("ASSET_CANNOT_BE_FOUND");
            }

            return asset;
            
        }

       
    }
}
