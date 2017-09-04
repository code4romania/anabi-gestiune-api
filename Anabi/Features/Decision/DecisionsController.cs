using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Controllers;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain;
using Anabi.Features.Decision.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Anabi.Features.Decision
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class DecisionsController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IGenericRepository<DecisionDb> repository;
        public DecisionsController(IGenericRepository<DecisionDb> repo,
            IMediator _mediator)
        {
            repository = repo;
            mediator = _mediator;
        }

        System.Linq.Expressions.Expression<Func<DecisionDb, Domain.Models.Decision>> selector = c => new Domain.Models.Decision()
        {
            Name = c.Name,
            Id = c.Id,
            PossibleStages = (List<Domain.Models.Stage>)c.PossibleStages
        };

        // GET: api/Decisions
        [HttpGet()]
        public async Task<IEnumerable<Domain.Models.Decision>> Get()
        {
                return await repository.GetAll().Select(selector).ToListAsync();
        }

        // GET: api/Decisions/5
        [HttpGet("{id}")]
        public async Task<Domain.Models.Decision> Get(int id)
        {
            try
            {

                return await repository.FindBy(p => p.Id == id).Select(selector).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<DecisionSummary>> Search(SearchDecision filter)
        {
            var results = await mediator.Send(filter);

            return results;
        }
    }
}