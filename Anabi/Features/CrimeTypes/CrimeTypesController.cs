using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Common.Cache;
using Anabi.Controllers;
using Anabi.Features.CrimeTypes.Models;
using Anabi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.CrimeTypes
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/crimetypes")]
    public class CrimeTypesController : CacheableController
    {
        private readonly IMediator mediator;

        public CrimeTypesController(IMediator _mediator, AnabiCacheManager _cache)
            :base(_cache)
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

            var models = await this.GetOrSetFromCacheAsync(
                key: CacheKeys.CrimeTypesList,
                size: 2,
                deleg: () => mediator.Send(new GetCrimeTypes() { Id = null })
                );
                
            return Ok(models);

        }
    }
}