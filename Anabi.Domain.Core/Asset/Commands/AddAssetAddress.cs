using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Ef;
using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using MediatR;
using Anabi.Validators.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Anabi.Domain.Asset.Commands.Models;
using Microsoft.EntityFrameworkCore;


namespace Anabi.Domain.Asset.Commands
{
    public class AddAssetAddress : AddAssetAddressRequest, IRequest<AddressViewModel>
    {
        public int AssetId { get; set; }

        public AddAssetAddress(int assetId)
        {
            AssetId = assetId;
        }
        
        public AddAssetAddress()
        {
            
        }
    }

    public class AddAssetAddressValidator : AbstractValidator<AddAssetAddress>
    {
        private readonly AnabiContext context;
        public AddAssetAddressValidator(AnabiContext ctx, IAssetValidator validator)
        {
            context = ctx;

            RuleFor(p => p.AssetId).MustAsync(validator.AssetIdExistsInDatabaseAsync).WithMessage(Constants.ASSET_INVALID_ID);
            RuleFor(p => p.CountyId).MustAsync(CountyIdExistsInDatabaseAsync).WithMessage(Constants.COUNTY_INVALID_ID);
            RuleFor(p => p.Street).NotEmpty().MaximumLength(100).WithMessage(Constants.ADDRESS_STREET_INVALID_NAME);
            RuleFor(p => p.City).NotEmpty().MaximumLength(30).WithMessage(Constants.ADDRESS_CITY_INVALID_NAME);
            RuleFor(p => p.Building).NotEmpty().MaximumLength(10).WithMessage(Constants.ADDRESS_BUILDING_INVALID_NUMBER);
            RuleFor(p => p.Description).NotEmpty().MaximumLength(300).WithMessage(Constants.ADDRESS_DESCRIPTION_INVALID);
        }

        private async Task<bool> CountyIdExistsInDatabaseAsync(int arg1, CancellationToken arg2)
        {
            if (arg1 <= 0)
            {
                return false;
            }
            var exists = await context.Counties.AnyAsync(x => x.Id == arg1);
            return exists;
        }
    }
}