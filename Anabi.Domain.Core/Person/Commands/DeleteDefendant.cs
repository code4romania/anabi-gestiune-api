using Anabi.Common.Utils;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Person.Commands
{
    public class DeleteDefendant : IRequest
    {
        public int AssetId { get; set; }
        public int DefendantId { get; set; }
    }

    public class DeleteDefendantValidator: AbstractValidator<DeleteDefendant>
    {
        private readonly AnabiContext context;

        public DeleteDefendantValidator(AnabiContext ctx)
        {
            this.context = ctx;
            RuleFor(m => m.AssetId).GreaterThan(0).WithMessage(Constants.ASSET_ID_MUST_BE_SPECIFIED);
            RuleFor(m => m.DefendantId).GreaterThan(0).WithMessage(Constants.DEFENDANT_ID_MUST_BE_SPECIFIED);
            RuleFor(m => m.AssetId).MustAsync(AssetExist).WithMessage(Constants.ASSET_INVALID_ID);
            RuleFor(m => m.DefendantId).MustAsync(DefendantExist).WithMessage(Constants.DEFENDANT_INVALID_ID);
            RuleFor(m => m).MustAsync(AssetDefendantExist).WithMessage(Constants.ASSET_DEFENDANT_INVALID_IDS);
        }

        private async Task<bool> AssetExist(int assetId, CancellationToken cancellationToken)
        {
            var assetExists = await context.Assets.AnyAsync(a => a.Id == assetId);
            return assetExists;
        }

        private async Task<bool> DefendantExist(int defendantId, CancellationToken cancellationToken)
        {
            var defendantExists = await context.Persons.AnyAsync(p => p.Id == defendantId);
            return defendantExists;
        }

        private async Task<bool> AssetDefendantExist(DeleteDefendant command, CancellationToken cancellationToken)
        {
            var assetDefendantExists = await context.AssetDefendants
                    .AnyAsync(x => x.AssetId == command.AssetId && x.PersonId == command.DefendantId);
            return assetDefendantExists;
        }
    }
}
