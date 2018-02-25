using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Controllers;
using Anabi.Domain.Models;
using Anabi.Features.Counties.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Anabi.Features.Counties
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/Counties")]
    public class CountiesController : BaseController
    {
        private readonly IMediator _mediator;

        public CountiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET /api/Counties
        [HttpGet]
        public async Task<IEnumerable<County>> Get()
        {
            var models = await _mediator.Send(new GetCounties());
            return models;
        }

    }
}