using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Anabi.Features.Search.Models;

namespace Anabi.Features.Search
{
    public class SearchAssetHandler : BaseHandler, IRequestHandler<SearchAssetCriteria, List<SearchAssetResult>>
    {
        public SearchAssetHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        /**
         * Method that returns a search result  
         * */
        public async Task<List<SearchAssetResult>> Handle(SearchAssetCriteria message, CancellationToken cancellationToken)
        {
            var query = from historicalStages in context.HistoricalStages
                        join assets in context.Assets on historicalStages.AssetId equals assets.Id
                        join assetDefendant in context.AssetDefendants on assets.Id equals assetDefendant.AssetId
                        join person in context.Persons on assetDefendant.PersonId equals person.Id
                        join stages in context.Stages on historicalStages.StageId equals stages.Id

                        where historicalStages.DecisionNumber == message.DecisionNumber
                        where historicalStages.FileNumber == message.FileNumber
                        where historicalStages.Person.Identification == message.DefendantId //maybe should be changed
                        where historicalStages.Person.Name == message.DefendantName
                        select new SearchAssetResult
                        {
                            Id = historicalStages.DecizieId,
                            DefendantName = person.Name,
                            DecisionNumber = historicalStages.DecisionNumber,
                            FileNumber = historicalStages.FileNumber,
                            Stage = historicalStages.Stage.Name,
                            AssetId = assets.Id
                        };
                                                                      
            return await query.ToListAsync(cancellationToken);
        }
    }
}
