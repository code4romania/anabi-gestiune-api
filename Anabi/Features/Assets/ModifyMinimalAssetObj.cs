using Anabi.Common.ViewModels;
using Anabi.Domain.Core.Asset.Commands;
using MediatR;

namespace Anabi.Features.Assets
{
    public class ModifyMinimalAssetObj : IRequest<MinimalAssetViewModel>
    {
        public int Id { get; set; }
        public ModifyMinimalAsset ModifyMinimalAsset { get; set; }
    }
}