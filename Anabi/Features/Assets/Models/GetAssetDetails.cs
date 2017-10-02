using MediatR;

namespace Anabi.Features.Assets.Models
{
    public class GetAssetDetails : IRequest<AssetDetails>
    {
        public int Id { get; set; }
    }
}
