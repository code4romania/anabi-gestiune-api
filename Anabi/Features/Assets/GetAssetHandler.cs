using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using Anabi.Common.Exceptions;

namespace Anabi.Features.Assets
{
    public class GetAssetHandler : BaseHandler, IAsyncRequestHandler<GetAssetDetails, AssetViewModel>
    {
        public GetAssetHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task<AssetViewModel> Handle(GetAssetDetails message)
        {

            var asset = await (from a in context.Assets
                               //last stage of the asset
                               from historicalStage in context.HistoricalStages
                                        .Where(x => x.AssetId == a.Id)
                                        .OrderByDescending(x => x.Id)
                                        .Take(1)
                               where a.Id == message.Id
                         select new AssetViewModel()
                         {
                             AddedDate = a.AddedDate,
                             CategoryId = a.CategoryId,
                             Description = a.Description,
                             EstimatedAmount = historicalStage.EstimatedAmount.Value,
                             EstimatedAmountCurrency = historicalStage.EstimatedAmountCurrency,
                             Id = a.Id,
                             Identifier = a.Identifier,
                             LastChangedDate = a.LastChangeDate,
                             MeasureUnit = a.MeasureUnit,
                             Name = a.Name,
                             Quantity = (a.NrOfObjects ?? 0),
                             StageId = historicalStage.StageId,
                             UserCodeAdd = a.UserCodeAdd,
                             UserCodeLastChange = a.UserCodeLastChange
                         })
                         .FirstOrDefaultAsync();

            if (asset == null)
            {
                throw new AnabiEntityNotFoundException("ASSET_CANNOT_BE_FOUND");
            }

            return asset;
            
        }

       
    }
}
