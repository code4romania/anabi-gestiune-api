using Anabi.Common.Utils;
using Anabi.DataAccess.Ef;
using Anabi.Domain.Asset.Commands.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset.Commands
{
    public class AddSolution : IRequest<int>
    {
        public AddSolution(int assetId, int stageId, int decisionId
            ,int institutionId, DateTime decisionDate, string decisionNumber,
            int? recoveryBeneficiaryId,
            RecoveryDetails recoveryDetails,
            SolutionDetails solutionDetails)
        {
            AssetId = assetId;
            StageId = stageId;
            DecisionId = decisionId;
            InstitutionId = institutionId;
            DecisionDate = decisionDate;
            DecisionNumber = decisionNumber;
            RecoveryBeneficiaryId = recoveryBeneficiaryId;
            RecoveryDetails = recoveryDetails;
            SolutionDetails = solutionDetails;
        }

        public int AssetId { get; }

        public int StageId { get; }

        public int DecisionId { get; }

        public int InstitutionId { get; }

        public DateTime DecisionDate { get; }

        public string DecisionNumber { get; }

        public int? RecoveryBeneficiaryId { get; }

        public RecoveryDetails RecoveryDetails { get; }

        public SolutionDetails SolutionDetails { get; }
    }

    public class AddSolutionValidator : AbstractValidator<AddSolution>
    {
        private readonly AnabiContext context;

        public AddSolutionValidator(AnabiContext ctx)
        {
            context = ctx;

            RuleFor(c => c.StageId).MustAsync(StageIdExistsInDatabaseAsync).WithMessage(Constants.STAGE_INVALID_ID);
            RuleFor(c => c.DecisionId).MustAsync(DecisionIdExistsInDatabaseAsync).WithMessage(Constants.DECISION_INVALID_ID);
            RuleFor(c => c.InstitutionId).MustAsync(InstitutionIdExistsInDatabaseAsync).WithMessage(Constants.INSTITUTION_INVALID_ID);
            RuleFor(c => c.RecoveryBeneficiaryId).MustAsync(RecoveryBeneficiaryIdShouldExistInDatabaseAsync).WithMessage(Constants.RECOVERYBENEFICIARY_INVALID_ID);
            RuleFor(c => c.DecisionNumber).NotEmpty().WithMessage(Constants.DECISIONNUMBER_NOT_VALID);

            //Dependend rules for Recovery and Solution details
        }

        private async Task<bool> RecoveryBeneficiaryIdShouldExistInDatabaseAsync(int? arg1, CancellationToken arg2)
        {
            if (arg1 == null)
            {
                return true;
            }

            if (arg1 == 0)
            {
                return false;
            }

            var exists = await context.RecoveryBeneficiaries.AnyAsync(x => x.Id == arg1, arg2);
            return exists;
        }

        private async Task<bool> InstitutionIdExistsInDatabaseAsync(int arg1, CancellationToken arg2)
        {
            if (arg1 == 0)
            {
                return false;
            }
            var exists = await context.Institutions.AnyAsync(x => x.Id == arg1, arg2);
            return exists;
        }

        private async Task<bool> DecisionIdExistsInDatabaseAsync(int arg1, CancellationToken arg2)
        {
            if (arg1 == 0)
            {
                return false;
            }

            var exists = await context.Decisions.AnyAsync(x => x.Id == arg1, arg2);
            return exists;
        }

        private async Task<bool> StageIdExistsInDatabaseAsync(int arg1, CancellationToken arg2)
        {
            if (arg1 == 0)
            {
                return false;
            }
            var exists = await context.Stages.AnyAsync(x => x.Id == arg1);
            return exists;
        }


    }
}
