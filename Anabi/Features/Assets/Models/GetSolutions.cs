using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.Validators.Interfaces;
using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.Assets.Models
{
    public class GetSolutions : IRequest<List<SolutionViewModel>>
    {
        public GetSolutions(int assetId)
        {
            AssetId = assetId;
        }

        public int AssetId { get; }
    }

    public class GetSolutionsValidator : AbstractValidator<GetSolutions>
    {
        public GetSolutionsValidator(IAssetValidator _validator)
        {
            RuleFor(c => c.AssetId).MustAsync(_validator.AssetIdExistsInDatabaseAsync).WithMessage(Constants.ASSET_INVALID_ID);
        }
    }
}
