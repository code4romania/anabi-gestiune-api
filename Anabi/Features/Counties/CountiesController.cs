using System.Collections.Generic;
using System.Threading.Tasks;
using Anabi.Controllers;
using Anabi.Domain.Models;
using Anabi.Features.Counties.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Anabi.Infrastructure;
using Anabi.Common.Cache;

namespace Anabi.Features.Counties
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/Counties")]
    public class CountiesController : CacheableController
    {
        private readonly IMediator _mediator;

        public CountiesController(IMediator mediator, AnabiCacheManager _cache)
            : base(_cache)
        {
            _mediator = mediator;
        }

        //GET /api/Counties
        [HttpGet]
        public async Task<IEnumerable<County>> Get()
        {
            var models = await this.GetOrSetFromCacheAsync(
                key: CacheKeys.CountiesList,
                size: 10,
                deleg: () => _mediator.Send(new GetCounties()));

            return models;
        }

    }
}