using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Features.Person.Models;
using Anabi.Middleware;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Anabi.Features.Person
{
    [Route("api")]
    [AllowAnonymous]
    public class PersonController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;


        public PersonController(IMediator _mediator, IMapper _mapper)
        {
            mediator = _mediator;
            mapper = _mapper;
        }
        

        // GET: api/identifiers
        /// <summary>
        /// Returns identifiers in the database
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns identifiers in the database filtered for person type (person or company)
        /// </para>
        /// </remarks>
        /// <response code="200">Array of Identifiers</response>
        /// <response code="400">No identifiers found!</response>
        /// <param name="isForPerson"></param>
        [ProducesResponseType(typeof(List<Models.Identifier>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("person/identifiers")]
        public async Task<IActionResult> GetIdentifiers(bool isForPerson)
        {

            var models = await mediator.Send(new GetIdentifier() { IsForPerson = isForPerson });
            return Ok(models);

        }
    }
}
