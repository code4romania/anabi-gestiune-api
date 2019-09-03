using Anabi.Features.Institution.Models;
using Anabi.Middleware;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Anabi.Domain.Institution.Commands;
using Microsoft.AspNetCore.Authorization;
using Anabi.Infrastructure;
using Anabi.Common.Cache;

namespace Anabi.Features.Institution
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InstitutionsController : CacheableController
    {
        private readonly IMediator mediator;
        

        public InstitutionsController(IMediator mediator, AnabiCacheManager cache) 
            : base(cache)
        {
            this.mediator = mediator;
        }

        [ProducesResponseType(typeof(List<Models.Institution>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await this.GetOrSetFromCacheAsync(
                key: CacheKeys.InstitutionList, 
                size: 500, 
                deleg: () => this.mediator.Send(new Models.GetInstitution()));

            return Ok(models);
        }

        [ProducesResponseType(typeof(Models.Institution), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await this.GetOrSetFromCacheAsync(
                key: $"{CacheKeys.Institution}_{id}",
                size: 1,
                deleg: () => this.mediator.Send(new GetInstitution { Id = id }));

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddInstitution([FromBody]AddInstitution institution)
        {
            var id = await this.mediator.Send(institution);
            _cache.Cache.Remove(CacheKeys.InstitutionList);
            return Created("api/institutions", id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditInstitution([FromBody]EditInstitution institution)
        {        
            await this.mediator.Send(institution);
            _cache.Cache.Remove($"{CacheKeys.Institution}_{institution.Id}");
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody]DeleteInstitution institution)
        {           
            await this.mediator.Send(institution);
            _cache.Cache.Remove($"{CacheKeys.Institution}_{institution.Id}");
            return Ok();
        }
    }
}