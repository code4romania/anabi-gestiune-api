using Anabi.Common.ViewModels;
using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Features.Assets
{
    public class GetSolutionsHandler : BaseHandler, IRequestHandler<GetSolutions, List<SolutionViewModel>>
    {
        public GetSolutionsHandler(BaseHandlerNeeds needs) : base(needs)
        {

        }

        public async Task<List<SolutionViewModel>> Handle(GetSolutions message, CancellationToken cancellationToken)
        {

            var result = await context.HistoricalStages
                .Where(p => p.AssetId == message.AssetId)
                .Select(h => new SolutionViewModel
                {
                    DecisionDate = h.DecisionDate,
                    DecisionId = h.DecizieId,
                    DecisionNumber = h.DecisionNumber,
                    Id = h.Id,
                    InstitutionId = h.InstitutionId,
                    StageId = h.StageId,
                    ConfiscationDetails = new ConfiscationDetailsViewModel(h.RecoveryBeneficiaryId),
                    RecoveryDetails = new RecoveryDetailsViewModel (h.ActualValue, h.EstimatedAmount, h.EstimatedAmountCurrency, h.ActualValueCurrency, h.RecoveryState, 
                                                 new EvaluationCommitteeViewModel(h.EvaluationCommitteeDesignationDate, h.EvaluationCommitteePresident, h.EvaluationCommittee),
                                                    new RecoveryCommitteeViewModel(h.RecoveryCommitteeDesignationDate, h.RecoveryCommitteePresident, h.RecoveryCommittee),
                    h.LastActivity, h.PersonResponsible, h.RecoveryApplicationNumber, h.RecoveryApplicationDate, h.RecoveryDocumentType, h.RecoveryIssuingInstitution),
                    SolutionDetails = new SolutionDetailsViewModel(h.Source, h.SentOnEmail, h.FileNumber, h.FileNumberParquet, h.ReceivingDate, h.IsDefinitive, h.DefinitiveDate, h.SendToAuthoritiesDate, h.CrimeTypeId, h.LegalBasis),
                    Journal = new JournalViewModel
                    {
                        AddedDate = h.AddedDate,
                        UserCodeAdd = h.UserCodeAdd,
                        LastChangeDate = h.LastChangeDate,
                        UserCodeLastChange = h.UserCodeLastChange
                    },
                    SequesterDetails = new SequesterDetailsViewModel(h.PrecautionaryMeasureId)
                }).
                ToListAsync(cancellationToken);

            return result;

        }
    }
}
