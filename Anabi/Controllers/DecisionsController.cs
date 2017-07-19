using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Anabi.DataAccess.Abstractions.Repositories;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DecisionsController : BaseController
    {
        private readonly IGenericRepository<DecisionDb> repository;
        public DecisionsController(IGenericRepository<DecisionDb> repo)
        {
            repository = repo;
        }

        System.Linq.Expressions.Expression<Func<DecisionDb, Decision>> selector = c => new Decision()
        {
            Name = c.Name,
            Id = c.Id,
            PossibleStages = (List<Stage>)c.PossibleStages
        };

        // GET: api/Decisions
        [HttpGet()]
        public async Task<IEnumerable<Decision>> Get()
        {
                return await repository.GetAll().Select(selector).ToListAsync();
        }

        // GET: api/Decisions/5
        [HttpGet("{id}")]
        public async Task<Decision> Get(int id)
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
    }
}