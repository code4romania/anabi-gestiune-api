using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.Domain.Asset.Commands;
using FluentValidation;
using MediatR;

namespace Anabi.Domain.Core.Asset.Commands
{
    public class ModifyMinimalAssetRequest : IRequest<MinimalAssetViewModel>, IMinimalAsset
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int SubcategoryId { get; set; }

        public string Identifier { get; set; }

        public string Remarks { get; set; }

        public int StageId { get; set; }

        public decimal Quantity { get; set; }

        public string MeasureUnit { get; set; }

        public decimal EstimatedAmount { get; set; }

        public string EstimatedAmountCurrency { get; set; }

    }

    public class ModifyMinimalAssetValidator: MinimalAssetValidator<ModifyMinimalAssetRequest> {

    }
}
