using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.Validators.Interfaces;
using FluentValidation;
using MediatR;

namespace Anabi.Features.Assets.Models
{
    public class GetAssetAddress : IRequest<AddressViewModel>
    {
        public int AssetId { get; }

        public GetAssetAddress(int assetId)
        {
            AssetId = assetId;
        }
    }

    public class GetAssetAddressValidator : AbstractValidator<GetAssetAddress>
    {
        public GetAssetAddressValidator(IAssetValidator validator)
        {
            RuleFor(g => g.AssetId).GreaterThan(0).WithMessage(Constants.INVALID_ID);
            RuleFor(p => p.AssetId).MustAsync(validator.AssetIdExistsInDatabaseAsync).WithMessage(Constants.ASSET_INVALID_ID);
        }
    }
}
