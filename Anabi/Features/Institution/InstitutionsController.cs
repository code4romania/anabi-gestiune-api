namespace Anabi.Features.Institution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Anabi.Controllers;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;
    using Anabi.Domain.Institution.Commands;

    using FluentValidation;

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InstitutionsController : BaseController
    {
        private readonly IMediator mediator;

        public InstitutionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Models.Institution>> Get()
        {
            var results = await this.mediator.Send(new Models.GetInstitution());

            return results;
        }

        [HttpGet("{id}")]
        public async Task<Models.Institution> Get(int id)
        {
            var results = await this.mediator.Send(new Models.GetInstitution { Id = id });

            return results.SingleOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> AddInstitution(AddInstitution institution)
        {
         var id =       await this.mediator.Send(institution);

            return Created("api/Instituions", id);
        }

        [HttpPut]
        public async Task<IActionResult> EditInstitution(EditInstitution institution)
        {
         
                await this.mediator.Send(institution);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteInstitution institution)
        {
           
                await this.mediator.Send(institution);
            return Ok();
        }
    }
}