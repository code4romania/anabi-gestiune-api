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
    public class DeleteOwner : IRequest
    {
        public int AssetId { get; set; }
        public int OwnerId { get; set; }
    }

    public class DeleteOwnerValidator : AbstractValidator<DeleteOwner>
    {
        private readonly AnabiContext context;

        public DeleteOwnerValidator(AnabiContext ctx)
        {
            this.context = ctx;
            RuleFor(m => m.AssetId).MustBeInDbSet(context.Assets).WithMessage(Constants.ASSET_INVALID_ID);
            RuleFor(m => m.OwnerId).MustBeInDbSet(context.Persons).WithMessage(Constants.OWNER_INVALID_ID);
            RuleFor(m => m).MustAsync(AssetOwnerExist).WithMessage(Constants.ASSET_OWNER_INVALID_IDS);
        }

        private async Task<bool> AssetOwnerExist(DeleteOwner command, CancellationToken cancellationToken)
        {
            var assetOwnerExists = await context.AssetOwners
                    .AnyAsync(x => x.AssetId == command.AssetId && x.PersonId == command.OwnerId);
            return assetOwnerExists;
        }
    }
}
