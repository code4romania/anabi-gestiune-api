using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Anabi.Domain;
using Anabi.Features.Decision.Models;
using Anabi.DataAccess.Ef;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Decision
{
    public class SearchDecisionHandler : BaseHandler, IAsyncRequestHandler<SearchDecision, List<DecisionSummary>>
    {
        public SearchDecisionHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public Task<List<DecisionSummary>> Handle(SearchDecision message)
        {
            var query = from asset in context.Bunuri
                        join assetFile in context.BunuriDosare on asset.Id equals assetFile.AssetId
                        join file in context.Dosare on assetFile.FileId equals file.Id
                        join fileNumber in context.NumereDosare on file.CurrentFileNumber equals fileNumber.FileNumber
                        join historicalStage in context.EtapeIstorice on asset.Id equals historicalStage.AssetId
                        join institution in context.Institutii on historicalStage.InstitutionId equals institution.Id
                        join defendant in context.InculpatiDosar on file.Id equals defendant.FileId
                        join person in context.Persoane on defendant.PersonId equals person.Id
                        where asset.CurrentStageId == historicalStage.StageId
                        where (string.IsNullOrEmpty(message.PersonID) || person.Identification == message.PersonID)
                        where (string.IsNullOrEmpty(message.PersonName) || person.Name == message.PersonName)
                        select new DecisionSummary
                        {
                            FileNumber = file.CurrentFileNumber,
                            Number = historicalStage.DecisionNumber,
                            Date = historicalStage.DecisionDate,
                            EmitterInstitution = institution.Name,
                            HistoricalStageId = historicalStage.Id
                        };

            if (!string.IsNullOrEmpty(message.DecisionNumber))
            {
                query = query.Where(q => q.Number == message.DecisionNumber);
            }

            if (!string.IsNullOrEmpty(message.FileNumber))
            {
                query = query.Where(q => q.FileNumber == message.FileNumber);
            }

            return query.ToListAsync();
        }
    }
}
