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

        private readonly AbstractValidator<AddInstitution> addInstitutionValidator;

        private readonly AbstractValidator<EditInstitution> editInstitutionValidator;

        private readonly AbstractValidator<DeleteInstitution> deleteInstitutionValidator;

        public InstitutionsController(IMediator mediator, 
            AbstractValidator<AddInstitution> addInstitutionValidator, 
            AbstractValidator<EditInstitution> editInstitutionValidator, 
            AbstractValidator<DeleteInstitution> deleteInstitutionValidator)
        {
            this.mediator = mediator;
            this.addInstitutionValidator = addInstitutionValidator;
            this.editInstitutionValidator = editInstitutionValidator;
            this.deleteInstitutionValidator = deleteInstitutionValidator;
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
        public async Task<HttpResponseMessage> AddInstitution(AddInstitution institution)
        {
            var validationResult = this.addInstitutionValidator.Validate(institution);
            if (validationResult.IsValid)
            {
                await this.mediator.Send(institution);
            }

            return ErrorHelper.GenerateErrorResponse(validationResult, "Error adding institution");
        }

        [HttpPut]
        public async Task<HttpResponseMessage> EditInstitution(EditInstitution institution)
        {
            var validationResult = this.editInstitutionValidator.Validate(institution);
            if (validationResult.IsValid)
            {
                await this.mediator.Send(institution);
            }

            return ErrorHelper.GenerateErrorResponse(validationResult, "Error editing institution");
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(DeleteInstitution institution)
        {
            var validationResult = this.deleteInstitutionValidator.Validate(institution);
            if (validationResult.IsValid)
            {
                await this.mediator.Send(institution);
            }

            return ErrorHelper.GenerateErrorResponse(validationResult, "Error deleting institution");
        }
    }
}