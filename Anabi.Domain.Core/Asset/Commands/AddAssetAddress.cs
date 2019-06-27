using Anabi.DataAccess.Ef;
using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using MediatR;
using Anabi.Validators.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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
        public AddAssetAddressValidator(AnabiContext ctx, IAssetValidator validator)
        {
            context = ctx;

            RuleFor(p => p.AssetId).MustAsync(validator.AssetIdExistsInDatabaseAsync).WithMessage(Constants.ASSET_INVALID_ID);
            RuleFor(p => p.CountyId).MustAsync(CountyIdExistsInDatabaseAsync).WithMessage(Constants.COUNTY_INVALID_ID);
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