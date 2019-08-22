using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Anabi.Validators.Extensions;

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
        private AnabiContext context;

        public GetOwnersValidator(AnabiContext ctx)
        {
            context = ctx;
            RuleFor(c => c.AssetId).MustBeInDbSet(context.Assets).WithMessage(Constants.ASSET_INVALID_ID);
        }
    }
}