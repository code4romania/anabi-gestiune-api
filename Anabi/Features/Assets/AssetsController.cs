using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Anabi.Features.Assets.Models;
using MediatR;

namespace Anabi.Features.Assets
{
    [Produces("application/json")]
    [Route("api/Assets")]
    public class AssetsController : Controller
    {
        private readonly IMediator mediator;
        public AssetsController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        // GET: api/Assets/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<AssetDetails> Get(int id)
        {
            var model = await mediator.Send(new GetAssetDetails { Id = id });

            return model;
        }
        
        
    }
}
