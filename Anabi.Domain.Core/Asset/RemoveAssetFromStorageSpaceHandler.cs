using Anabi.Domain.Asset.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class RemoveAssetFromStorageSpaceHandler : BaseHandler
        , IRequestHandler<RemoveAssetFromStorageSpace>
    {
        public RemoveAssetFromStorageSpaceHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<Unit> Handle(RemoveAssetFromStorageSpace request, CancellationToken cancellationToken)
        {
            var entityToRemove = await context.AssetStorageSpaces.SingleAsync(x => x.AssetId == request.AssetId && x.StorageSpaceId == request.StorageSpaceId);
            context.AssetStorageSpaces.Remove(entityToRemove);

            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
