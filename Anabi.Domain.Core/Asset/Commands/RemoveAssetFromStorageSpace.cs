using System;
using System.Threading;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Domain.Asset.Commands
{
    public class RemoveAssetFromStorageSpace : IRequest
    {
        public RemoveAssetFromStorageSpace(int assetId, int storageSpaceId)
        {
            AssetId = assetId;
            StorageSpaceId = storageSpaceId;
        }

        public int AssetId { get; }

        public int StorageSpaceId { get; }
    }

    public class RemoveAssetFromStorageSpaceAssetIdValidator: AbstractValidator<RemoveAssetFromStorageSpace>
    {
        private readonly AnabiContext context;

        public RemoveAssetFromStorageSpaceAssetIdValidator(AnabiContext ctx)
        {
            context = ctx;

            RuleFor(c => c).MustAsync(CombinationExists).WithMessage("INVALID_ASSETID_STORAGESPACEID");
        }

        private async Task<bool> CombinationExists(RemoveAssetFromStorageSpace arg1, CancellationToken arg2)
        {
            var exists = await context.AssetStorageSpaces.AnyAsync(x => x.AssetId == arg1.AssetId && x.StorageSpaceId == arg1.StorageSpaceId);
            return exists;
        }
    }
}
