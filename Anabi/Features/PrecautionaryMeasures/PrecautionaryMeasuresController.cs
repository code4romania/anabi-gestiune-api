using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Common.Cache;
using Anabi.Controllers;
using Anabi.Infrastructure;
using Anabi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.PrecautionaryMeasures
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/precautionarymeasures")]
    public class PrecautionaryMeasuresController : CacheableController
    {
        private readonly IMediator mediator;

        public PrecautionaryMeasuresController(IMediator _mediator, AnabiCacheManager _cache)
            : base(_cache)
        {
            mediator = _mediator;
        }

        /// <summary>
        /// Returns a list of precautionary measures (masuri asiguratorii)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<MeasuresDictionaryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetMeasures()
        {
            var models = await this.GetOrSetFromCacheAsync(
                key: CacheKeys.PrecautionayMeasuresList,
                size: 2,
                deleg: () => mediator.Send(new GetPrecautionaryMeasuresQuery()));

            return Ok(models);
        }
    }
}