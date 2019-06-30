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

using Anabi.Features.Search.Models;
namespace Anabi.Features.Search
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/search")]
    public class SearchController : BaseController
    {
        private readonly IMediator mediator;

        public SearchController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("asset")]
        [ProducesResponseType(typeof(IEnumerable<SearchAssetResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchAsset(SearchAssetCriteria assetCriteria)
        {
            var results = await mediator.Send(assetCriteria);

            return Ok();

        }
    }
}
