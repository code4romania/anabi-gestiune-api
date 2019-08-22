using Anabi.Common.Utils;
using Anabi.DataAccess.Ef;
using Anabi.Validators.Extensions;
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
            RuleFor(m => m.AssetId).MustBeInDbSet(context.Assets).WithMessage(Constants.ASSET_INVALID_ID);
            RuleFor(m => m.DefendantId).MustBeInDbSet(context.Persons).WithMessage(Constants.DEFENDANT_INVALID_ID);
            RuleFor(m => m).MustAsync(AssetDefendantExist).WithMessage(Constants.ASSET_DEFENDANT_INVALID_IDS);
        }

        private async Task<bool> AssetDefendantExist(DeleteDefendant command, CancellationToken cancellationToken)
        {
            var assetDefendantExists = await context.AssetDefendants
                    .AnyAsync(x => x.AssetId == command.AssetId && x.PersonId == command.DefendantId);
            return assetDefendantExists;
        }
    }
}
