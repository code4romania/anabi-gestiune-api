using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using MediatR;
using Anabi.Validators.Extensions;
using Anabi.DataAccess.Ef;

namespace Anabi.Features.Assets.Models
{
    public class GetAssetDetails : IRequest<MinimalAssetViewModel>
    {
        public int Id { get; set; }

    }

    public class GetAssetDetailsValidator : AbstractValidator<GetAssetDetails>
    {
        public GetAssetDetailsValidator(AnabiContext context)
        {
            RuleFor(g => g.Id).MustBeInDbSet(context.Assets).WithMessage(Constants.INVALID_ID);
        }
    }
}
