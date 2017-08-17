using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Anabi.Domain.Core.Models;
using MediatR;
using Anabi.Features.Dictionaries.Category;
using FluentValidation;
using System.Net.Http;
using System.Net;
using Anabi.Features;

namespace Anabi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CategoriesController : BaseController
    {
        private readonly IMediator mediator;
        private readonly AbstractValidator<AddCategoryQuery> addCategoryValidator;
        private readonly AbstractValidator<EditCategoryQuery> editCategoryValidator;
        private readonly AbstractValidator<DeleteCategoryQuery> deleteCategoryValidator;

        public CategoriesController(IMediator _mediator, 
            AbstractValidator<AddCategoryQuery> _addCategoryValidator, 
            AbstractValidator<EditCategoryQuery> _editCategoryValidator,
            AbstractValidator<DeleteCategoryQuery> _deleteCategoryValidator)
        {
            mediator = _mediator;

            addCategoryValidator = _addCategoryValidator;
            editCategoryValidator = _editCategoryValidator;
            deleteCategoryValidator = _deleteCategoryValidator;
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
        //[ValidateAntiForgeryToken]
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
                return ErrorHelper.GenerateErrorResponse(validationResult, "Errors adding new category");
            }

        }

        

        // PUT: api/Categories/5  ("{id}")
        [HttpPut]
        //[ValidateAntiForgeryToken]
        public async Task<HttpResponseMessage> Put(EditCategoryQuery category)
        {
            var validationResult = editCategoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                await mediator.Send(category);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return ErrorHelper.GenerateErrorResponse(validationResult, "Errors editing category");
            }
        }

                
        [HttpDelete]
        //[ValidateAntiForgeryToken]
        public async Task<HttpResponseMessage> Delete(DeleteCategoryQuery category)
        {
            var validationResult = deleteCategoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                await mediator.Send(category);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return ErrorHelper.GenerateErrorResponse(validationResult, "Errors deleting category");
            }
        }


       
    }
}
