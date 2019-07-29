using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.Validators.Interfaces;
using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.Owner.Models
{
    public class GetOwners : IRequest<List<OwnerViewModel>>
    {
        public GetOwners(int assetId)
        {
            AssetId = assetId;
        }

        public int AssetId { get; }
    }

    public class GetOwnersValidator : AbstractValidator<GetOwners>
    {
        public GetOwnersValidator(IAssetValidator _validator)
        {
            RuleFor(c => c.AssetId).MustAsync(_validator.AssetIdExistsInDatabaseAsync).WithMessage(Constants.ASSET_INVALID_ID);
        }
    }
}