using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.Domain.Person.Commands;
using Anabi.Features.Defendant.Models;
using Anabi.Middleware;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anabi.Features.Defendant
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api")]
    public class DefendantController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public DefendantController(IMediator _mediator, IMapper _mapper)
        {
            mediator = _mediator;
            mapper = _mapper;
        }

        //POST api/<controller>
        /// <summary>
        /// Creates a new defendant
        /// </summary>
        /// <remarks>
        /// <para>
        /// Creates a new defendant by adding a new Person record and a new AssetDefendants record. 
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
        /// <response code="201">Id of the new defendant</response>
        /// <response code="400">Validation errors</response>
        /// <param name="assetId">Asset id where the defendant is added to</param>
        /// <param name="addPerson">Details for new defendant</param>
        [ProducesResponseType(typeof(DefendantViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("assets/{assetId}/defendant")]
        public async Task<IActionResult> AddDefendant(int assetId, [FromBody]AddDefendantRequest addPerson)
        {
            var message = mapper.Map<AddDefendantRequest, AddDefendant>(addPerson);
            message.AssetId = assetId;

            var model = await mediator.Send(message);
            return Created("api/person", model);

        }

        //PUT api/assets/{assetId}/defendant/{defendantId}
        /// <summary>
        /// Modifies a defendant
        /// </summary>
        /// <remarks>
        /// <para>
        /// Modifies a defendant by modifying the existing person. 
        /// Checks that the AssetId provided exists in the database
        /// Checks that the DefendantId provided exists in the database
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
        ///DEFENDANT_INVALID_ID 
        ///ASSET_INVALID_ID 
        ///PERSONIDENTIFICATION_ALREADY_EXISTS 
        ///ASSET_DEFENDANT_INVALID_IDS 
        /// 
        /// </para>
        /// </remarks>
        /// <response code="200">Id of the modified defendant</response>
        /// <response code="400">Validation errors</response>
        /// <param name="assetId">Asset id of the modified defendant</param>
        /// <param name="defendantId">Id of the modified defendant</param>
        /// <param name="modifyDefendantRequest">Details for the modified defendant</param>
        [ProducesResponseType(typeof(DefendantViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPut("assets/{assetId}/defendant/{defendantId}")]
        public async Task<IActionResult> ModifyDefendant(int assetId, int defendantId, [FromBody]ModifyDefendantRequest modifyDefendantRequest)
        {
            var message = mapper.Map<ModifyDefendantRequest, ModifyDefendant>(modifyDefendantRequest);
            message.AssetId = assetId;
            message.DefendantId = defendantId;

            var model = await mediator.Send(message);
            return Ok(model);
        }

        /// <summary>
        /// Returns the list of defendants for a given asset id
        /// </summary>
        /// <response code="200">The list of defendants for a given asset id</response>
        /// <response code="400">Validation errors</response>
        /// <param name="assetId">Asset id</param>
        [ProducesResponseType(typeof(List<DefendantViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("assets/{assetId}/defendants")]
        public async Task<IActionResult> GetDefendantsList(int assetId)
        {
            var defendants = await mediator.Send(new GetDefendants(assetId));

            return Ok(defendants);
        }
        /// <summary>
        /// Deletes a defendant from an asset along with 
        /// </summary>
        /// <response code="200">The defendant has been successfully deleted</response>
        /// <response code="400">Validation errors</response>
        /// <param name="assetId">Asset id</param>
        /// <param name="defendantId">Defendant id</param>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpDelete("assets/{assetId}/defendants/{defendantId}")]
        public async Task<IActionResult> DeleteDefendant(int assetId, int defendantId)
        {
            var request = new DeleteDefendant { AssetId = assetId, DefendantId = defendantId };
            await mediator.Send(request);
            return Ok();
        }
    }
}