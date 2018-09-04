using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using System.Collections.Generic;
using Anabi.Domain.Asset.Commands;

namespace Anabi.Domain.Core.Asset.Commands
{
    public abstract class MinimalAssetValidator<T>: AbstractValidator<T> where T: IMinimalAsset
    {
    public MinimalAssetValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(Constants.NAME_NOT_EMPTY);
            RuleFor(c => c.Name).MaximumLength(100).WithMessage(Constants.NAME_MAX_LENGTH_100);

            
            RuleFor(c => c.Identifier).MaximumLength(100).WithMessage(Constants.IDENTIFIER_MAX_LENGTH_100);

            RuleFor(c => c.StageId).GreaterThan(0).WithMessage(Constants.STAGE_INVALID_ID);
            RuleFor(c => c.SubcategoryId).GreaterThan(0).WithMessage(Constants.CATEGORY_INVALID_ID);

            RuleFor(c => c.MeasureUnit).MaximumLength(10).WithMessage(Constants.MEASUREUNIT_MAX_LENGTH_10);
            
            
            RuleFor(c => c.EstimatedAmountCurrency).Length(3).Unless(x => string.IsNullOrEmpty(x.EstimatedAmountCurrency))
                .WithMessage(Constants.ESTIMATED_AMT_CURRENCY_THREE_CHARS);

        }
    }
}
