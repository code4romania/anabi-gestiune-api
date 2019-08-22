﻿using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using Anabi.Domain.Asset.Commands.Models;
using Anabi.Validators.Extensions;
using FluentValidation;
using MediatR;
using System;

namespace Anabi.Domain.Asset.Commands
{
    public class AddSolution : AddSolutionRequest, IRequest<SolutionViewModel>
    {
        public AddSolution(int stageId, int decisionId
            , int institutionId, DateTime decisionDate, string decisionNumber,
            ConfiscationDetails confiscationDetails,
            RecoveryDetails recoveryDetails,
            SolutionDetails solutionDetails,
            SequesterDetails sequesterDetails) : base (stageId,
                decisionId,
                institutionId,
                decisionDate,
                decisionNumber,
                confiscationDetails,
                recoveryDetails,
                solutionDetails,
                sequesterDetails)
        {
            
        }

        public int AssetId { get; set; }
    }

    public class AddSolutionValidator : AbstractValidator<AddSolution>
    {
        private readonly AnabiContext context;

        public AddSolutionValidator(AnabiContext ctx)
        {
            context = ctx;
            RuleFor(c => c.AssetId).MustBeInDbSet(context.Assets).WithMessage(Constants.ASSET_INVALID_ID);
            RuleFor(c => c.StageId).MustBeInDbSet(context.Stages).WithMessage(Constants.STAGE_INVALID_ID);
            RuleFor(c => c.DecisionId).MustBeInDbSet(context.Decisions).WithMessage(Constants.DECISION_INVALID_ID);
            RuleFor(c => c.InstitutionId).MustBeInDbSet(context.Institutions).WithMessage(Constants.INSTITUTION_INVALID_ID);

            RuleFor(c => c.ConfiscationDetails.RecoveryBeneficiaryId).ShouldBeInDbSet(context.RecoveryBeneficiaries)
                .When(c => c.ConfiscationDetails != null)
                .WithMessage(Constants.RECOVERYBENEFICIARY_INVALID_ID)
                ;

            RuleFor(c => c.SequesterDetails.PrecautionaryMeasureId).ShouldBeInDbSet(context.Assets)
                .When(c => c.SequesterDetails != null)
                .WithMessage(Constants.PRECAUTIONARYMEASURE_INVALID_ID)
                ;

            RuleFor(c => c.DecisionNumber).NotEmpty().MaximumLength(50).WithMessage(Constants.DECISION_DECISIONNUMBER_INVALID);

            RuleFor(c => c.DecisionDate).NotEmpty().WithMessage(Constants.DECISION_DECISIONDATE_INVALID);

            RuleFor(c => c.SolutionDetails.FileNumber).NotEmpty().MaximumLength(200).When(c => c.SolutionDetails != null)
                .WithMessage(Constants.SOLUTION_FILENUMBER_INVALID);
            RuleFor(c => c.SolutionDetails.FileNumberParquet).MaximumLength(200).When(c => c.SolutionDetails != null)
                .WithMessage(Constants.SOLUTION_FILENUMBERPARQUET_INVALID);

            RuleFor(c => c.SolutionDetails.ReceivingDate).NotEmpty().When(c => c.SolutionDetails != null)
                .WithMessage(Constants.SOLUTION_RECEIVINGDATE_INVALID);

            RuleFor(c => c.RecoveryDetails.PersonResponsible)
                .NotEmpty()
                .MaximumLength(200)
                .When(c => c.RecoveryDetails != null)
                .WithMessage(Constants.RECOVERY_PERSONRESPONSIBLE_INVALID);

            RuleFor(c => c.RecoveryDetails.EstimatedAmount)
                .GreaterThan(0)
                .When(c => c.RecoveryDetails != null)
                .WithMessage(Constants.RECOVERY_ESTIMATEDAMOUNT_GREATER_THAN_ZERO);

            RuleFor(c => c.RecoveryDetails.EstimatedAmountCurrency)
                .Length(3)
                .When(c => c.RecoveryDetails != null)
                .WithMessage(Constants.RECOVERY_ESTIMATEDAMOUNTCURRENCY_3_CHARS);

            RuleFor(c => c.RecoveryDetails.ActualAmount)
                .GreaterThan(0)
                .When(c => c.RecoveryDetails != null)
                .WithMessage(Constants.RECOVERY_ACTUALAMOUNT_GREATER_THAN_ZERO);

            RuleFor(c => c.RecoveryDetails.ActualAmountCurrency)
                .Length(3)
                .When(c => c.RecoveryDetails != null)
                .WithMessage(Constants.RECOVERY_ACTUALAMOUNTCURRENCY_3_CHARS);

            RuleFor(c => c.RecoveryDetails.RecoveryCommittee.RecoveryCommitteePresident)
                .MaximumLength(200)
                .When(c => c.RecoveryDetails != null && c.RecoveryDetails.RecoveryCommittee != null)
                .WithMessage(Constants.RECOVERY_RECOVERYCOMMITTEEPRESIDENT_MAX_LENGTH_200);

            RuleFor(c => c.RecoveryDetails.EvaluationCommittee.EvaluationCommitteePresident)
                .MaximumLength(200)
                .When(c => c.RecoveryDetails != null && c.RecoveryDetails.EvaluationCommittee != null)
                .WithMessage(Constants.RECOVERY_EVALUATIONCOMMITTEEPRESIDENT_MAX_LENGTH_200);
        }
    }
}
