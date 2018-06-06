using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using MediatR;

namespace Anabi.Features.Assets.Models
{
    public class GetAssetDetails : IRequest<MinimalAssetViewModel>
    {
        public int Id { get; set; }

    }

    public class GetAssetDetailsValidator : AbstractValidator<GetAssetDetails>
    {
        public GetAssetDetailsValidator()
        {
            RuleFor(g => g.Id).GreaterThan(0).WithMessage(Constants.INVALID_ID);
        }
    }
}
