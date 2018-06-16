using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Features.Common.Models;
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
    public class PrecautionaryMeasuresController : Controller
    {
        private readonly IMediator mediator;

        public PrecautionaryMeasuresController(IMediator _mediator)
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
            var models = await mediator.Send(new GetPrecautionaryMeasuresQuery());

            return Ok(models);
        }
    }
}