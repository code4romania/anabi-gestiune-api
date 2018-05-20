using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Features.Decisions.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.Decisions
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/decisions")]
    public class DecisionsController : Controller
    {
        private readonly IMediator mediator;

        public DecisionsController(IMediator _mediator)
        {
            mediator = _mediator;

        }

        /// <summary>
        /// Returns all decision types in the database
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns all decision types in the database
        /// </para>
        /// </remarks>
        /// <response code="200">Array of decision types</response>
        [ProducesResponseType(typeof(List<Decision>), StatusCodes.Status200OK)]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {

            var models = await mediator.Send(new GetDecision() { Id = null });
            return Ok(models);

        }

    }
}