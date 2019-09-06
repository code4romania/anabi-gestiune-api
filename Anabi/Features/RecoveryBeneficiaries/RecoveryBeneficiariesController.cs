using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Common.Cache;
using Anabi.Controllers;
using Anabi.Features.RecoveryBeneficiaries.Models;
using Anabi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.RecoveryBeneficiaries
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/recoverybeneficiaries")]
    public class RecoveryBeneficiariesController : CacheableController
    {
        private readonly IMediator mediator;

        public RecoveryBeneficiariesController(IMediator _mediator, AnabiCacheManager _cache)
            : base(_cache)
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
            var models = await this.GetOrSetFromCacheAsync(
                key: CacheKeys.RecoveryBeneficiariesList,
                size: 2,
                deleg: () => mediator.Send(new GetBeneficiaries() { Id = null }));

            return Ok(models);

        }
    }
}