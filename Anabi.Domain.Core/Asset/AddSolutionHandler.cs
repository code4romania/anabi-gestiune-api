﻿using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Ef.DbModels.Extensions;
using Anabi.Domain.Asset.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class AddSolutionHandler : BaseHandler
        , IRequestHandler<AddSolution, SolutionViewModel>
    {
        public AddSolutionHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<SolutionViewModel> Handle(AddSolution message, CancellationToken cancellationToken)
        {

            var newStage = new HistoricalStageDb
            {
                AssetId = message.AssetId,
                StageId = message.StageId,
                DecizieId = message.DecisionId,
                InstitutionId = message.InstitutionId,
                DecisionDate = message.DecisionDate,
                DecisionNumber = message.DecisionNumber,
                RecoveryBeneficiaryId = message.ConfiscationDetails?.RecoveryBeneficiaryId,
                AddedDate = DateTime.Now,
                UserCodeAdd = UserCode(),
                PrecautionaryMeasureId = message.SequesterDetails?.PrecautionaryMeasureId
            };
            
            newStage.ActualValue = message.RecoveryDetails?.ActualAmount;
            newStage.EstimatedAmount = message.RecoveryDetails?.EstimatedAmount;
            newStage.EstimatedAmountCurrency = message.RecoveryDetails?.EstimatedAmountCurrency;
            newStage.ActualValueCurrency = message.RecoveryDetails?.ActualAmountCurrency;
            newStage.RecoveryState = message.RecoveryDetails?.RecoveryState;

            newStage.EvaluationCommittee = message.RecoveryDetails?.EvaluationCommittee?.EvaluationCommitteeMembers;
            newStage.EvaluationCommitteePresident = message.RecoveryDetails?.EvaluationCommittee?.EvaluationCommitteePresident;
            newStage.EvaluationCommitteeDesignationDate = message.RecoveryDetails?.EvaluationCommittee?.EvaluationCommitteeDesignationDate;

            newStage.RecoveryCommittee = message.RecoveryDetails?.RecoveryCommittee?.RecoveryCommitteeMembers;
            newStage.RecoveryCommitteePresident = message.RecoveryDetails?.RecoveryCommittee?.RecoveryCommitteePresident;
            newStage.RecoveryCommitteeDesignationDate = message.RecoveryDetails?.RecoveryCommittee?.RecoveryCommitteeDesignationDate;

            newStage.LastActivity = message.RecoveryDetails?.LastActivity;
            newStage.PersonResponsible = message.RecoveryDetails?.PersonResponsible;

            newStage.Source = message.SolutionDetails?.Source;
            newStage.SentOnEmail = message.SolutionDetails?.SentOnEmail;
            newStage.FileNumber = message.SolutionDetails?.FileNumber;
            newStage.FileNumberParquet = message.SolutionDetails?.FileNumberParquet;
            newStage.ReceivingDate = message.SolutionDetails?.ReceivingDate;
            newStage.IsDefinitive = message.SolutionDetails?.IsDefinitive;
            newStage.DefinitiveDate = message.SolutionDetails?.DefinitiveDate;
            newStage.SendToAuthoritiesDate = message.SolutionDetails?.SentToAuthoritiesDate;
            newStage.CrimeTypeId = message.SolutionDetails?.CrimeTypeId;
            newStage.LegalBasis = message.SolutionDetails?.LegalBasis;

            newStage.RecoveryApplicationNumber = message.RecoveryDetails?.RecoveryApplicationNumber;
            newStage.RecoveryApplicationDate = message.RecoveryDetails?.RecoveryApplicationDate;
            newStage.RecoveryDocumentType = message.RecoveryDetails?.RecoveryDocumentType;
            newStage.RecoveryIssuingInstitution = message.RecoveryDetails?.RecoveryIssuingInstitution;

            context.HistoricalStages.Add(newStage);
            await context.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<AddSolution, SolutionViewModel>(message);
            response.Id = newStage.Id;
            response.Journal = newStage.GetJournalViewModel();

            return response;
        }
    }
}
