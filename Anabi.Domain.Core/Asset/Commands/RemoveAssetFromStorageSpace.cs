using FluentValidation;
using MediatR;

namespace Anabi.Domain.Asset.Commands
{
    public class RemoveAssetFromStorageSpace : IRequest
    {
        public int AssetId { get; set; }

        public int StorageSpaceId { get; set; }
    }

    public class RemoveAssetFromStorageSpaceAssetIdValidator: AbstractValidator<RemoveAssetFromStorageSpace>
    {
        public RemoveAssetFromStorageSpaceAssetIdValidator()
        {
            
        }

    }
}
