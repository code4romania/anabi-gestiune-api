using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Features.RecoveryBeneficiaries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.RecoveryBeneficiaries
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/recoverybeneficiaries")]
    public class RecoveryBeneficiariesController : Controller
    {
        private readonly IMediator mediator;

        public RecoveryBeneficiariesController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        /// <summary>
        /// Returns all recovery beneficiaries in the database
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns all recovery beneficiaries in the database
        /// </para>
        /// </remarks>
        /// <response code="200">Array of recovery beneficiaries</response>
        [ProducesResponseType(typeof(List<Beneficiary>), StatusCodes.Status200OK)]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {

            var models = await mediator.Send(new GetBeneficiaries() { Id = null });
            return Ok(models);

        }
    }
}