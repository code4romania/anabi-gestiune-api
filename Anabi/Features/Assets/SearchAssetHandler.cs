using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Assets
{
    public class SearchAssetHandler : BaseHandler, IAsyncRequestHandler<SearchAsset, List<AssetSummary>>
    {
        public SearchAssetHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<List<AssetSummary>> Handle(SearchAsset message)
        {
            var query = from asset in context.Assets
                        join subcat in context.Categories on asset.CategoryId equals subcat.Id
                        join cat in context.Categories on subcat.ParentId equals cat.Id
                        
                        from historicalStage in context.HistoricalStages
                                                .Where(x => x.AssetId == asset.Id)
                                                .OrderByDescending(x => x.Id)
                                                .Take(1) 
                            join stage in context.Stages on historicalStage.StageId equals stage.Id                       
                            orderby asset.Id descending
                        select new AssetSummary
                        {
                            AssetSubcategory = subcat.Code,
                            AssetCategory = cat.Code,
                            AssetId = asset.Id,
                            AssetName = asset.Name,
                            EstimatedAmount = historicalStage.EstimatedAmount,
                            EstimatedAmountCurrency = historicalStage.EstimatedAmountCurrency,
                            AssetIdentifier = asset.Identifier,
                            CurrentStage = stage.Name  
                        };

            return await query.ToListAsync();

        }
    }
}
