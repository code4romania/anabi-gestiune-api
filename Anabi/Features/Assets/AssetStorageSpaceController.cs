using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Anabi.Domain.Asset.Commands;
using Anabi.Middleware;
using Anabi.Common.ViewModels;
using AutoMapper;
using Anabi.Domain.Asset;

namespace Anabi.Features.Assets
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("/api/assets")]
    public class AssetStorageSpaceController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public AssetStorageSpaceController(IMediator _mediator, IMapper _mapper)
        {
            mediator = _mediator;
            mapper = _mapper;
        }

        [ProducesResponseType(typeof(AssetStorageSpaceViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPut("{assetId}/storagespace")]
        public async Task<IActionResult> AddStorageSpaceToAsset(int assetId, [FromBody] AddAssetToStorageSpaceRequest assetStorageSpaceDb)
        {
            var assetStorageSpace = new AddAssetStorageSpace
            {
                AssetId = assetId,
                StorageSpaceId = assetStorageSpaceDb.StorageSpaceId,
                EntryDate = assetStorageSpaceDb.EntryDate
            };
            var viewModel = await mediator.Send(assetStorageSpace);

            return Ok(viewModel);
        }

        /// <summary>
        /// Removes an asset from a storage space
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="storageSpaceId"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpDelete("{assetId}/storagespace/{storageSpaceId}")]
        public async Task<IActionResult> RemoveAssetFromStorageSpace(int assetId, int storageSpaceId)
        {
            var command = new RemoveAssetFromStorageSpace(assetId, storageSpaceId);
            await mediator.Send(command);
            return NoContent();
        }
    }


}