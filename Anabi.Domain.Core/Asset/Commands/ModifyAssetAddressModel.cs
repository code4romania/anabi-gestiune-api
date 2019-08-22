using Anabi.Common.ViewModels;
using MediatR;
using Anabi.DataAccess.Ef;
using Anabi.Common.Utils;
using FluentValidation;
using Anabi.Validators.Extensions;

namespace Anabi.Domain.Core.Asset.Commands
{
    public class ModifyAssetAddressModel : ModifyAssetAddressRequest, IRequest<AddressViewModel>
    {
        public int AssetId { get; set; }

        public ModifyAssetAddressRequest ModifyAssetAddress 
        {
            get
            {
                return this;
            }
            set
            {
                this.CountyId = value.CountyId;
                this.Street = value.Street;
                this.City = value.City;
                this.Building = value.Building;
                this.Description = value.Description;
            }
        }
    }

    public class ModifyAssetAddressValidator : AbstractValidator<ModifyAssetAddressModel>
    {
        private readonly AnabiContext context;
        public ModifyAssetAddressValidator(AnabiContext ctx)
        {
            context = ctx;

            RuleFor(p => p.AssetId).MustBeInDbSet(context.Assets).WithMessage(Constants.ASSET_INVALID_ID);
            RuleFor(p => p.CountyId).MustBeInDbSet(context.Counties).WithMessage(Constants.COUNTY_INVALID_ID);
            RuleFor(p => p.Street).NotEmpty().MaximumLength(100).WithMessage(Constants.ADDRESS_STREET_INVALID_NAME);
            RuleFor(p => p.City).NotEmpty().MaximumLength(30).WithMessage(Constants.ADDRESS_CITY_INVALID_NAME);
            RuleFor(p => p.Building).NotEmpty().MaximumLength(10).WithMessage(Constants.ADDRESS_BUILDING_INVALID_NUMBER);
            RuleFor(p => p.Description).NotEmpty().MaximumLength(300).WithMessage(Constants.ADDRESS_DESCRIPTION_INVALID);
        }
    }
}
