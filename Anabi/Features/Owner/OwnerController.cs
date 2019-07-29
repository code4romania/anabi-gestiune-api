using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.Domain.Person.Commands;
using Anabi.Features.Owner.Models;
using Anabi.Middleware;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.Owner
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api")]
    public class OwnerController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public OwnerController(IMediator _mediator, IMapper _mapper)
        {
            mediator = _mediator;
            mapper = _mapper;
        }

        //POST api/<controller>
        /// <summary>
        /// Creates a new owner
        /// </summary>
        /// <remarks>
        /// <para>
        /// Creates a new owner by adding a new Person record and a new AssetOwners record. 
        /// Checks that the AssetId provided exists in the database
        /// 
        /// Validation errors:
        /// 
        ///IDNUMBER_MAX_LENGTH_6;
        ///IDSERIE_MAX_LENGTH_2;
        ///IDENTIFICATION_MAX_LENGTH_20;
        ///PERSONNAME_MAX_LENGTH_200;
        ///FIRSTNAME_MAX_LENGTH_50;
        ///NATIONALITY_MAX_LENGTH_20;
        ///IDENTIFICATION_CANNOT_BE_EMPTY;
        ///PERSONNAME_CANNOT_BE_EMPTY;
        ///PERSONIDENTIFICATION_ALREADY_EXISTS;
        ///ASSET_INVALID_ID
        /// </para>
        /// </remarks>
        /// <response code="201">Id of the new owner</response>
        /// <response code="400">Validation errors</response>
        /// <param name="assetId">Asset id where the owner is added to</param>
        /// <param name="addPerson">Details for new owner</param>
        [ProducesResponseType(typeof(OwnerViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("assets/{assetId}/owner")]
        public async Task<IActionResult> AddOwner(int assetId, [FromBody]AddOwnerRequest addPerson)
        {
            var message = mapper.Map<AddOwnerRequest, AddOwner>(addPerson);
            message.AssetId = assetId;

            var model = await mediator.Send(message);
            return Created("api/person", model);

        }

        //PUT api/assets/{assetId}/owner/{ownerId}
        /// <summary>
        /// Modifies a owner
        /// </summary>
        /// <remarks>
        /// <para>
        /// Modifies a owner by modifying the existing person. 
        /// Checks that the AssetId provided exists in the database
        /// Checks that the OwnerId provided exists in the database
        /// 
        /// Validation errors:
        /// 
        ///IDNUMBER_MAX_LENGTH_6;
        ///IDSERIE_MAX_LENGTH_2;
        ///IDENTIFICATION_MAX_LENGTH_20
        ///IDENTIFICATION_CANNOT_BE_EMPTY
        ///PERSONNAME_MAX_LENGTH_200 
        ///PERSONNAME_CANNOT_BE_EMPTY 
        ///FIRSTNAME_MAX_LENGTH_50 
        ///NATIONALITY_MAX_LENGTH_20 
        ///OWNER_INVALID_ID 
        ///ASSET_INVALID_ID 
        ///PERSONIDENTIFICATION_ALREADY_EXISTS 
        ///ASSET_OWNER_INVALID_IDS 
        /// 
        /// </para>
        /// </remarks>
        /// <response code="200">Id of the modified owner</response>
        /// <response code="400">Validation errors</response>
        /// <param name="assetId">Asset id of the modified owner</param>
        /// <param name="ownerId">Id of the modified owner</param>
        /// <param name="modifyOwnerRequest">Details for the modified owner</param>
        [ProducesResponseType(typeof(OwnerViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPut("assets/{assetId}/owner/{ownerId}")]
        public async Task<IActionResult> ModifyOwner(int assetId, int OwnerId, [FromBody]ModifyOwnerRequest modifyOwnerRequest)
        {
            var message = mapper.Map<ModifyOwnerRequest, ModifyOwner>(modifyOwnerRequest);
            message.AssetId = assetId;
            message.OwnerId = OwnerId;

            var model = await mediator.Send(message);
            return Ok(model);
        }

        /// <summary>
        /// Returns the list of owners for a given asset id
        /// </summary>
        /// <response code="200">The list of owners for a given asset id</response>
        /// <response code="400">Validation errors</response>
        /// <param name="assetId">Asset id</param>
        [ProducesResponseType(typeof(List<OwnerViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("assets/{assetId}/owners")]
        public async Task<IActionResult> GetOwnersList(int assetId)
        {
            var owners = await mediator.Send(new GetOwners(assetId));

            return Ok(owners);
        }
        /// <summary>
        /// Deletes a owner from an asset along with 
        /// </summary>
        /// <response code="200">The owner has been successfully deleted</response>
        /// <response code="400">Validation errors</response>
        /// <param name="assetId">Asset id</param>
        /// <param name="ownerId">Owner id</param>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpDelete("assets/{assetId}/owners/{ownerId}")]
        public async Task<IActionResult> DeleteOwner(int assetId, int ownerId)
        {
            var request = new DeleteOwner { AssetId = assetId, OwnerId = ownerId };
            await mediator.Send(request);
            return Ok();
        }
    }
}