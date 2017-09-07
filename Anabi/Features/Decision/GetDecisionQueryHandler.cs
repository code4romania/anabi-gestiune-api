using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Anabi.Domain;
using Anabi.Features.Decision.Models;

namespace Anabi.Features.Decision
{
    public class GetDecisionQueryHandler : BaseHandler, IAsyncRequestHandler<GetDecisionDetails, List<DecisionDetails>>
    {
        public GetDecisionQueryHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {

        }
        public async Task<List<DecisionDetails>> Handle(GetDecisionDetails message)
        {

            var query = (from h in context.EtapeIstorice
                         join a in context.Bunuri on h.AssetId equals a.Id
                         join d in context.Decizii on h.DecizieId equals d.Id
                         join i in context.Institutii on h.InstitutionId equals i.Id
                         join p in context.Persoane on h.OwnerId equals p.Id
                         join s in context.Etape on h.StageId equals s.Id
                         select new { historicalStage = h, asset = a,
                             decisionDictionary = d, institutionDictionary = i,
                         person = p, stageDictionary = s}
                         );
                
                //context.EtapeIstorice.AsQueryable();

            if (message.Id != null)
            {
                query = query.Where(i => i.historicalStage.Id == message.Id);
            }

            var model = await query.Select(x => new DecisionDetails
            {
                Id = x.historicalStage.Id,
                ActualValue = x.historicalStage.ActualValue,
                ActualValueCurrency = x.historicalStage.ActualValueCurrency,
                AddedDate = x.historicalStage.AddedDate,
                AssetId = x.historicalStage.AssetId,
                AssetState = x.historicalStage.AssetState,
                AssetUniqueIdentifier = x.asset.Identifier,
                DecisionDate = x.historicalStage.DecisionDate,
                DecisionName = x.decisionDictionary.Name,
                DecisionNumber = x.historicalStage.DecisionNumber,
                DecizieId = x.decisionDictionary.Id,
                EstimatedAmount = x.historicalStage.EstimatedAmount,
                EstimatedAmountCurrency = x.historicalStage.EstimatedAmountCurrency,
                InstitutionId = x.historicalStage.InstitutionId,
                InstitutionName = x.institutionDictionary.Name,
                LastChangeDate = x.historicalStage.LastChangeDate,
                LegalBasis = x.historicalStage.LegalBasis,
                OwnerId = x.historicalStage.OwnerId,
                OwnerName = x.person.Name,
                StageId = x.historicalStage.StageId,
                StageName = x.stageDictionary.Name,
                UserCodeAdd = x.historicalStage.UserCodeAdd,
                UserCodeLastChange = x.historicalStage.UserCodeLastChange
            }).ToListAsync();

            return model;
        }
    }
}
