using Anabi.Common.ViewModels;
using Anabi.Domain.Core.Asset.Commands;
using MediatR;

namespace Anabi.Domain.Core.Asset.Commands
{
    public class ModifyMinimalAssetModel : IRequest<MinimalAssetViewModel>
    {
        public int Id { get; set; }
        public ModifyMinimalAssetRequest ModifyMinimalAsset { get; set; }
    }
}