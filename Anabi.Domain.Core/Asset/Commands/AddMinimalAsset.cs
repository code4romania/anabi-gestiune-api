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

        public decimal Quantity { get; set; }

        public string MeasureUnit { get; set; }

        public decimal EstimatedAmount { get; set; }

        public string EstimatedAmountCurrency { get; set; }

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

            RuleFor(c => c.MeasureUnit).MaximumLength(10).WithMessage(Constants.MEASUREUNIT_MAX_LENGTH_10);
            RuleFor(c => c.Quantity).GreaterThan(0).WithMessage(Constants.QUANTITY_MUST_BE_GREATER_THAN_ZERO);
            RuleFor(c => c.EstimatedAmount).GreaterThan(0).WithMessage(Constants.ESTIMATED_AMOUNT_GREATER_THAN_ZERO);
            RuleFor(c => c.EstimatedAmountCurrency).Length(3).WithMessage(Constants.ESTIMATED_AMT_CURRENCY_THREE_CHARS);

        }
    }
}
