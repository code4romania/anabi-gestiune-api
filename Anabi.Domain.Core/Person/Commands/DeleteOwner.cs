using Anabi.Common.Utils;
using Anabi.DataAccess.Ef;
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
            RuleFor(m => m.AssetId).GreaterThan(0).WithMessage(Constants.ASSET_ID_MUST_BE_SPECIFIED);
            RuleFor(m => m.OwnerId).GreaterThan(0).WithMessage(Constants.OWNER_ID_MUST_BE_SPECIFIED);
            RuleFor(m => m.AssetId).MustAsync(AssetExist).WithMessage(Constants.ASSET_INVALID_ID);
            RuleFor(m => m.OwnerId).MustAsync(OwnerExist).WithMessage(Constants.OWNER_INVALID_ID);
            RuleFor(m => m).MustAsync(AssetOwnerExist).WithMessage(Constants.ASSET_OWNER_INVALID_IDS);
        }

        private async Task<bool> AssetExist(int assetId, CancellationToken cancellationToken)
        {
            var assetExists = await context.Assets.AnyAsync(a => a.Id == assetId);
            return assetExists;
        }

        private async Task<bool>OwnerExist(int ownerId, CancellationToken cancellationToken)
        {
            var ownerExists = await context.Persons.AnyAsync(p => p.Id == ownerId);
            return ownerExists;
        }

        private async Task<bool> AssetOwnerExist(DeleteOwner command, CancellationToken cancellationToken)
        {
            var assetOwnerExists = await context.AssetOwners
                    .AnyAsync(x => x.AssetId == command.AssetId && x.PersonId == command.OwnerId);
            return assetOwnerExists;
        }
    }
}
