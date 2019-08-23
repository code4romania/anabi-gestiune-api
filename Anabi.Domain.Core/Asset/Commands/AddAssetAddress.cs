using Anabi.DataAccess.Ef;
using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using MediatR;
using Anabi.Validators.Extensions;

namespace Anabi.Domain.Asset.Commands
{
    public class AddAssetAddress : AddAssetAddressRequest, IRequest<AddressViewModel>
    {
        public int AssetId { get; }

        public AddAssetAddress(int assetId, int countyId, string street, string city, string building, string description) 
            : base(countyId, street, city, building, description)
        {
            AssetId = assetId;
        }
    }

    public class AddAssetAddressValidator : AbstractValidator<AddAssetAddress>
    {
        private readonly AnabiContext context;
        public AddAssetAddressValidator(AnabiContext ctx)
        {
            context = ctx;

            RuleFor(p => p.AssetId).MustBeInDbSet(context.Assets).WithMessage(Constants.ASSET_INVALID_ID);
            RuleFor(p => p.CountyId).MustBeInDbSet(context.Counties).WithMessage(Constants.COUNTY_INVALID_ID);
        }
    }
}