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
        public SearchAssetHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task<List<AssetSummary>> Handle(SearchAsset message)
        {

            var query = from asset in context.Assets
                        join cat in context.Categories on asset.CategoryId equals cat.Id
                        join assetFile in context.BunuriDosare on asset.Id equals assetFile.AssetId
                        join file in context.Dosare on assetFile.FileId equals file.Id
                        join fileNumber in context.NumereDosare on file.CurrentFileNumber equals fileNumber.FileNumber
                        join defendant in context.InculpatiDosar on file.Id equals defendant.FileId
                        join person in context.Persons on defendant.PersonId equals person.Id

                        from historicalStage in context.HistoricalStages
                                                .Where(x => x.AssetId == asset.Id)
                                                .OrderByDescending(x => x.DecisionDate)
                                                .Take(1) 
                            join institution in context.Institutions on historicalStage.InstitutionId equals institution.Id
                            join decision in context.Decisions on historicalStage.DecizieId equals decision.Id
                            join stage in context.Stages on historicalStage.StageId equals stage.Id

                        where (string.IsNullOrEmpty(message.PersonID) || person.Identification == message.PersonID)
                        where (string.IsNullOrEmpty(message.PersonName) || person.Name == message.PersonName)
                        select new AssetSummary
                        {
                            FileNumber = file.InitialFileNumber,
                            AssetCategory = cat.Code,
                            AssetDescription = asset.Description,
                            AssetId = asset.Id,
                            AssetIdentifier = asset.Identifier,
                            Institution = institution.Name,
                            CurrentDecision = decision.Name,
                            CurrentStage = stage.Name
                            
                        };

            if (!string.IsNullOrEmpty(message.DecisionNumber))
            {
                query = query.Where(q => q.CurrentDecision == message.DecisionNumber);
            }

            if (!string.IsNullOrEmpty(message.FileNumber))
            {
                query = query.Where(q => q.FileNumber == message.FileNumber);
            }

            return await query.ToListAsync();

        }
    }
}
