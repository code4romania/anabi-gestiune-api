using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Anabi.Controllers;
using Anabi.Domain.Category;
using Anabi.Domain.Category.Commands;
using Anabi.Features.Category.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.Category
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CategoriesController : BaseController
    {
        private readonly IMediator mediator;
        private readonly AbstractValidator<AddCategory> addCategoryValidator;
        private readonly AbstractValidator<EditCategory> editCategoryValidator;
        private readonly AbstractValidator<DeleteCategory> deleteCategoryValidator;

        public CategoriesController(IMediator _mediator, 
            AbstractValidator<AddCategory> _addCategoryValidator, 
            AbstractValidator<EditCategory> _editCategoryValidator,
            AbstractValidator<DeleteCategory> _deleteCategoryValidator)
        {
            mediator = _mediator;

            addCategoryValidator = _addCategoryValidator;
            editCategoryValidator = _editCategoryValidator;
            deleteCategoryValidator = _deleteCategoryValidator;
        }

        // GET: api/Categories
        [HttpGet()]
        public async Task<IEnumerable<Models.Category>> Get()
        {
            var models = await mediator.Send(new GetCategory() { Id = null });

            return models;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<Models.Category> Get(int id)
        {
            var models = await mediator.Send(new GetCategory() { Id = id });
            var result = models.FirstOrDefault();
            return result;
        }

        // POST: api/Categories
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<HttpResponseMessage> Post(AddCategory newCategory)
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
        public async Task<HttpResponseMessage> Put(EditCategory category)
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
        public async Task<HttpResponseMessage> Delete(DeleteCategory category)
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
