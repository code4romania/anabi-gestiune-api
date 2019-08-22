using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Anabi.Validators.Extensions;
using Anabi.DataAccess.Ef;

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
        private AnabiContext context;

        public GetDefendantsValidator(AnabiContext ctx)
        {
            context = ctx;
            RuleFor(c => c.AssetId).MustBeInDbSet(context.Assets).WithMessage(Constants.ASSET_INVALID_ID);
        }
    }
}
