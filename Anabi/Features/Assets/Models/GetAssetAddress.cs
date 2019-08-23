using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using Anabi.Validators.Extensions;

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
        private readonly AnabiContext context;

        public GetAssetAddressValidator(AnabiContext ctx)
        {
            context = ctx;

            RuleFor(p => p.AssetId).MustBeInDbSet(context.Assets).WithMessage(Constants.ASSET_INVALID_ID);
        }
    }
}
