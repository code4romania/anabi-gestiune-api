using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Anabi.Validators.Extensions;

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
        private AnabiContext context;

        public GetSolutionsValidator(AnabiContext ctx)
        {
            context = ctx;
            RuleFor(c => c.AssetId).MustBeInDbSet(context.Assets).WithMessage(Constants.ASSET_INVALID_ID);
        }
    }
}
