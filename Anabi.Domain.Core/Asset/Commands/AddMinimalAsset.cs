using Anabi.Common.Utils;
using FluentValidation;
using MediatR;

namespace Anabi.Domain.Asset.Commands
{
    public class AddMinimalAsset : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string Identifier { get; set; }

        
        public int StageId { get; set; }
    }

    public class AddStorageSpaceValidator : AbstractValidator<AddMinimalAsset>
    {
        public AddStorageSpaceValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(Constants.NAME_NOT_EMPTY);
            RuleFor(c => c.Name).MaximumLength(200).WithMessage(Constants.NAME_MAX_LENGTH_200);

            RuleFor(c => c.Identifier).MaximumLength(200).WithMessage(Constants.IDENTIFIER_MAX_LENGTH_200);

            RuleFor(c => c.StageId).GreaterThan(0).WithMessage(Constants.STAGE_INVALID_ID);
            RuleFor(c => c.CategoryId).GreaterThan(0).WithMessage(Constants.CATEGORY_INVALID_ID);
        }
    }
}
