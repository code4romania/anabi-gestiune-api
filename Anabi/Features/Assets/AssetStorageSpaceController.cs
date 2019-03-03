using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Anabi.Features.Assets.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Anabi.Controllers;
using Anabi.Domain.Asset.Commands;
using Anabi.Middleware;
using Anabi.Common.ViewModels;
using Anabi.Domain.Core.Asset.Commands;
using AutoMapper;
using Anabi.DataAccess.Ef.DbModels;

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


        [ProducesResponseType(typeof(AddressViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPut("{assetId}/storagespace")]
        public async Task<IActionResult> AddStorageSpaceToAsset(int assetId, [FromBody] AssetStorageSpaceDb assetStorageSpaceDb)
        {
            var assetStorageSpace = new AddAssetStorageSpace { StorageSpaceId = assetId, EntryDate = assetStorageSpaceDb.EntryDate };//nu cred ca este bine
            var viewModel = await mediator.Send(assetStorageSpace);

            return Ok();

        }


    }
}