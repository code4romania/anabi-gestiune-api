using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Features.CrimeTypes.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.CrimeTypes
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/crimetypes")]
    public class CrimeTypesController : Controller
    {
        private readonly IMediator mediator;

        public CrimeTypesController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        /// <summary>
        /// Returns all crime types in the database
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns all crime types in the database
        /// </para>
        /// </remarks>
        /// <response code="200">Array of crime types</response>
        [ProducesResponseType(typeof(List<CrimeType>), StatusCodes.Status200OK)]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {

            var models = await mediator.Send(new GetCrimeTypes() { Id = null });
            return Ok(models);

        }
    }
}