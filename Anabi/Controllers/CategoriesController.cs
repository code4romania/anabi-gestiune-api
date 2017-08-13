using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Anabi.DataAccess.Abstractions.Repositories;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Anabi.Features.Dictionaries.Category;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;

namespace Anabi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CategoriesController : BaseController
    {
        private readonly IMediator mediator;
        private readonly AbstractValidator<AddCategoryQuery> addCategoryValidator;
        private readonly ILogger<CategoriesController> logger;

        public CategoriesController(IMediator _mediator, AbstractValidator<AddCategoryQuery> _addCategoryValidator, ILogger<CategoriesController> _logger)
        {
            mediator = _mediator;
            addCategoryValidator = _addCategoryValidator;
            logger = _logger;
        }

       

        // GET: api/Categories
        [HttpGet()]
        public async Task<IEnumerable<Category>> Get()
        {

            var models = await mediator.Send(new CategoryQuery() { Id = null });

            return models;

        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {

            var models = await mediator.Send(new CategoryQuery() { Id = id });
            var result = models.FirstOrDefault();
            return result;

        }

        // POST: api/Categories
        [HttpPost]
        public async Task<HttpResponseMessage> Post(AddCategoryQuery newCategory)
        {
            var validationResult = addCategoryValidator.Validate(newCategory);
            if (validationResult.IsValid)
            {
                await mediator.Send(newCategory);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                var errors = GetErrorMessages(validationResult);

                logger.LogError("Errors adding new category:{0}", errors);

                var response = new HttpResponseMessage(HttpStatusCode.BadRequest) {ReasonPhrase = errors };
                
                return response;
            }

        }

        private string GetErrorMessages(FluentValidation.Results.ValidationResult validationResult)
        {
            var errors = validationResult.Errors.ToList();
            string errorMessages = string.Empty;
            errors.ForEach(e => { errorMessages += e.ErrorMessage; });

            return errorMessages;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
