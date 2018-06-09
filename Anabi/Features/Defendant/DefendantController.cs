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
    }
}