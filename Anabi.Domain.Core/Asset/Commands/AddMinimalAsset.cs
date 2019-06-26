using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.Asset.Commands
{
    public class AddMinimalAsset : IRequest<MinimalAssetViewModel>
    {
        [Required(ErrorMessage = Constants.NAME_NOT_EMPTY)]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = Constants.NAME_MAX_LENGTH_100)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public int SubcategoryId { get; set; }

        [MaxLength(100, ErrorMessage = Constants.IDENTIFIER_MAX_LENGTH_100)]
        public string Identifier { get; set; }

        [MaxLength(2000, ErrorMessage = Constants.REMARKS_MAX_LENGTH_2000)]
        public string Remarks { get; set; }

        public int StageId { get; set; }

        public decimal Quantity { get; set; }

        [MaxLength(10, ErrorMessage = Constants.MEASUREUNIT_MAX_LENGTH_10)]
        public string MeasureUnit { get; set; }

        public decimal EstimatedAmount { get; set; }

        [MaxLength(3)]
        public string EstimatedAmountCurrency { get; set; }

    }

    public class AddMinimalAssetValidator : AbstractValidator<AddMinimalAsset>
    {
        public AddMinimalAssetValidator()
        {
            RuleFor(c => c.StageId).GreaterThan(0).WithMessage(Constants.STAGE_INVALID_ID);
            RuleFor(c => c.SubcategoryId).GreaterThan(0).WithMessage(Constants.CATEGORY_INVALID_ID);

            RuleFor(c => c.EstimatedAmountCurrency).Length(3).Unless(x => string.IsNullOrEmpty(x.EstimatedAmountCurrency))
                .WithMessage(Constants.ESTIMATED_AMT_CURRENCY_THREE_CHARS);

        }
    }
}
