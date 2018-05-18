using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Domain.Asset.Commands;
using Anabi.Features.Assets.Models;
using Anabi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.Assets
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api")]
    public class SolutionsController : Controller
    {
        private readonly IMediator mediator;

        public SolutionsController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        /// <summary>
        /// Adds a new solution for an Asset
        /// </summary>
        /// <response code="200">The id of the new solution</response>
        /// <response code="400">Validation errors</response>
        /// <param name="assetId"></param>
        /// <param name="request"></param>
        /// <returns>Id of the new solution</returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("assets/{assetId}/solutions")]
        public async Task<IActionResult> AddSolution(int assetId, [FromBody] AddSolutionRequest request)
        {
            //throw new NotImplementedException();
            var model = await mediator.Send(new AddSolution (assetId, 0, 0, 0, DateTime.Now, null, 0, null, null));

            return Ok(model);
        }
    }
}