using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Anabi.Features.Decision.Models;

namespace Anabi.Features.Decision
{
    [Produces("application/json")]
    [Route("api/DecisionDetails")]
    public class DecisionDetailsController : Controller
    {
        private readonly IMediator mediator;

        public DecisionDetailsController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        // GET: api/DecisionDetails
        [HttpGet]
        public async Task<List<DecisionDetails>> GetAsync()
        {

            var models = await mediator.Send(new GetDecisionDetails() { Id = null });
            return models;
        }

        // GET: api/DecisionDetails/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<DecisionDetails> GetAsync(int id)
        {
            var models = await mediator.Send(new GetDecisionDetails() { Id = id });
            var result = models.FirstOrDefault();
            return result;
        }
        
        // POST: api/DecisionDetails
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/DecisionDetails/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
