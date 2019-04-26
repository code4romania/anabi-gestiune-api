using Anabi.Features.Institution.Models;
using Anabi.Middleware;
using Microsoft.AspNetCore.Http;

namespace Anabi.Features.Institution
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Anabi.Controllers;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Anabi.Domain.Institution.Commands;
    using Microsoft.AspNetCore.Authorization;
    using Anabi.Common.Utils;

    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InstitutionsController : BaseController
    {
        private readonly IMediator mediator;

        public InstitutionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [ProducesResponseType(typeof(List<Models.Institution>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await this.mediator.Send(new Models.GetInstitution());

            return Ok(results);
        }

        [ProducesResponseType(typeof(Models.Institution), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            var models = await mediator.Send(new GetInstitution { Id = id });
            var result = models.FirstOrDefault();

            if (result == null)
            {
                return BadRequest(Constants.INSTITUTION_DOES_NOT_EXIST);
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddInstitution([FromBody]AddInstitution institution)
        {
            var id = await this.mediator.Send(institution);

            return Created("api/institutions", id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditInstitution([FromBody]EditInstitution institution)
        {        
            await this.mediator.Send(institution);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody]DeleteInstitution institution)
        {           
            await this.mediator.Send(institution);
            return Ok();
        }
    }
}