using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Controllers;
using Anabi.Domain.Category.Commands;
using Anabi.Features.Category.Models;
using Anabi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.Category
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CategoriesController : BaseController
    {
        private readonly IMediator mediator;


        
        public CategoriesController(IMediator _mediator)
        {
            mediator = _mediator;

        }

        // GET: api/Categories
        /// <summary>
        /// Returns all categories in the database
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns all categories in the database
        /// </para>
        /// </remarks>
        /// <response code="200">Array of categories</response>
        /// <response code="400">No categories found!</response>
        [ProducesResponseType(typeof(List<Models.Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            
            var models = await mediator.Send(new GetCategory() { Id = null });
            return Ok(models);
          
        }

        // GET: api/Categories/5
        /// <summary>
        /// Returns the category for the supplied id
        /// </summary>
        /// <response code="200">The category for the supplied id</response>
        /// <response code="400">The category is not found</response>
        /// <param name="id">Must be >= 0</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Models.Category), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id-ul trebuie sa fie >= 0");
            }

            var models = await mediator.Send(new GetCategory() { Id = id });
            var result = models.FirstOrDefault();

            if (result == null)
            {
                return BadRequest("Categoria nu exista!");
            }
            return Ok(result);
        }

        // POST: api/Categories
        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns the id of the newly created category.
        /// Validation Errors:
        ///RuleFor(c.Code).NotEmpty().WithMessage("CODE_MANDATORY"); //Code is mandatory!
        ///RuleFor(c.Code).Length(1, 100).WithMessage("CODE_LENGTH_1_TO_100"); //The code must be between 1 and 100 characters!
        ///RuleFor(c.Code).MustAsync(HaveUniqueCode).WithMessage("CODE_EXISTS_ON_DIFFERENT_CATEGORY"); //The code exists on another category!
        ///RuleFor(c.Description).Length(0, 4000).WithMessage("DESCRIPTION_MAX_LENGTH_4000");//Description cannot be bigger than 4000 characters!
        ///RuleFor(c.ForEntity).NotEmpty().WithMessage("FORENTITY_MUST_BE_SPECIFIED"); //ForEntity was not specified
        ///RuleFor(c.ForEntity).Length(1, 40).WithMessage("FORENTITY_MAX_LENGTH_40"); //ForEntity must have a max value of 40 characters
        /// </para>
        /// </remarks>
        /// <response code="201">The id of the new category</response>
        /// <response code="400">In case of validation errors</response>
        /// <param name="newCategory">The details of the new category to be added</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post(AddCategory newCategory)
        {

            var newId = await mediator.Send(newCategory);
            return Created("api/categories", newId);

        }



        // PUT: api/Categories/5  ("{id}")
        /// <summary>
        /// Edits an existing category
        /// </summary>
        /// <remarks>
        /// <para>
        /// RuleFor(c.Id).GreaterThan(0).WithMessage("ID_MUST_BE_SPECIFIED"); //"Id was not specified!"
        ///RuleFor(c.Code).NotEmpty().WithMessage("CODE_MANDATORY"); //"Code is mandatory"
        ///RuleFor(c.Code).Length(1, 100).WithMessage("CODE_LENGTH_1_TO_100"); //"The code must be between 1 and 100 characters!"
        ///RuleFor(c.Code).MustAsync((queryArgs, code, token) => HaveUniqueCode(queryArgs.Code, queryArgs.Id, token)).WithMessage("CODE_EXISTS_ON_DIFFERENT_CATEGORY");//"The code exists on another category!"
        ///RuleFor(c.Description).Length(0, 4000).WithMessage("DESCRIPTION_MAX_LENGTH_4000");//Description cannot be bigger than 4000 characters!
        ///RuleFor(c.ForEntity).NotEmpty().WithMessage("FORENTITY_MUST_BE_SPECIFIED"); //"ForEntity was not specified
        ///RuleFor(c.ForEntity).Length(1, 40).WithMessage("FORENTITY_MAX_LENGTH_40");//"ForEntity must have a max value of 40 characters
        /// </para>
        /// </remarks>
        /// <response code="200">No content</response>
        /// <response code="400">In case of validation errors</response>
        /// <param name="category"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Put(EditCategory category)
        {
            await mediator.Send(category);
            return Ok();
        }


        /// <summary>
        /// Deletes an existing category
        /// </summary>
        /// <remarks>
        /// <para>
        /// Checks if the category is not referenced in other tables.
        /// RuleFor(m.Id).GreaterThan(0).WithMessage("ID_MUST_BE_SPECIFIED");//Id was not specified!
        /// RuleFor(m).MustAsync(HaveNoChildren).WithMessage("CATEGORY_HAS_CHILDREN");//The category cannot be deleted because there are records that have a reference to it!
        /// </para>
        /// </remarks>
        /// <response code="200">No content</response>
        /// <response code="400">In case of validation errors (including references in other tables)</response>
        /// <param name="category"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategory category)
        {

            await mediator.Send(category);
            return Ok();

        }



    }
}
