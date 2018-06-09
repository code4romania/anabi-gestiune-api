using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.Validators.Interfaces;
using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.Defendant.Models
{
    public class GetDefendants : IRequest<List<DefendantViewModel>>
    {
        public GetDefendants(int assetId)
        {
            AssetId = assetId;
        }

        public int AssetId { get; }
    }

    public class GetDefendantsValidator : AbstractValidator<GetDefendants>
    {
        public GetDefendantsValidator(IAssetValidator _validator)
        {
            RuleFor(c => c.AssetId).MustAsync(_validator.AssetIdExistsInDatabaseAsync).WithMessage(Constants.ASSET_INVALID_ID);
        }
    }
}
