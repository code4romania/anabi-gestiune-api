using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Controllers;
using Anabi.Domain.StorageSpaces.Commands;
using Anabi.Features.StorageSpaces.Models;
using Anabi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Anabi.Common.ViewModels;

namespace Anabi.Features.StorageSpaces
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StorageSpacesController : BaseController
    {
        private readonly IMediator mediator;

        
        public StorageSpacesController(IMediator _mediator)
        {
            mediator = _mediator;
        }



        // GET: api/StorageSpaces

        /// <summary>
        /// Returns all storage spaces in the database
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns all storage spaces in the database
        /// Validation Errors: NO_STORAGE_SPACES_FOUND 
        /// </para>
        /// </remarks>
        /// <response code="200">Array of storage spaces</response>
        /// <response code="400">No storage spaces found!</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(List<StorageSpaceViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await mediator.Send(new GetStorageSpace { Id = null });
            return Ok(models);
        }

        // GET: api/StorageSpaces/5
        /// <summary>
        /// Returns the storage space for the supplied id
        /// </summary>
        /// <remarks>
        /// <para>
        /// Validation Errors: 
        /// INVALID_ID = id lower than or equal to 0 
        /// NO_STORAGE_SPACES_FOUND
        /// </para>
        /// </remarks>
        /// <response code="200">Array of storage spaces</response>
        /// <response code="400">No storage spaces found!</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(StorageSpaceViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var models = await mediator.Send(new GetStorageSpace { Id = id });  
            return Ok(models.First());
        }

        // POST: api/StorageSpaces
        /// <summary>
        /// Creates a new storage space
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns the id of the newly created storage space.
        /// Validation Errors:
        /// NAME_NOT_EMPTY
        /// NAME_MAX_LENGTH_200 
        /// CONTACTDATA_MAX_LENGTH_1000
        /// DESCRIPTION_MAX_LENGTH_2000
        /// </para>
        /// </remarks>
        /// <response code="201">The id of the new storage space</response>
        /// <response code="400">In case of validation errors</response>
        /// <response code="500">Server error</response>
        /// <param name="newStorageSpace">The details of the new storage space to be added</param>
        /// <returns>The id of the new storage space</returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddStorageSpace newStorageSpace)
        {

            var id = await mediator.Send(newStorageSpace);
            return Created("api/storagespaces", id);

        }


        /// <summary>
        /// Returns the storage space for the supplied id
        /// </summary>
        /// <remarks>
        /// <para>
        /// Validation Errors: 
        /// INVALID_ID = id lower than or equal to 0 
        /// NO_STORAGE_SPACES_FOUND
        /// NAME_NOT_EMPTY
        /// NAME_MAX_LENGTH_200 
        /// CONTACTDATA_MAX_LENGTH_1000
        /// DESCRIPTION_MAX_LENGTH_2000
        /// </para>
        /// </remarks>
        /// <response code="200">The edited version of the storage space</response>
        /// <response code="400">No storage spaces found!</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(StorageSpaceViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status500InternalServerError)]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody]EditStorageSpace storageSpace)
        {
            var editedStorageSpace = await mediator.Send(storageSpace);

            return Ok(editedStorageSpace);
        }

        /// <summary>
        /// Deletes the storage space for the supplied id after it checks that no entity is referencing the storage space you want to delete
        /// </summary>
        /// <remarks>
        /// <para>
        /// Validation Errors: 
        /// INVALID_ID = id lower than or equal to 0 
        /// ENTITY_IS_REFERENCED_BY_OTHER_ENTITIES = The entity is referenced in other tables and cannot be deleted
        /// </para>
        /// </remarks>
        /// <response code="204">The storage space has been deleted</response>
        /// <response code="400"></response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status500InternalServerError)]
        [HttpDelete()]
        public async Task<IActionResult> Delete([FromBody]DeleteStorageSpace storageSpace)
        {
            await mediator.Send(storageSpace);

            return NoContent();
        }
    }
}
