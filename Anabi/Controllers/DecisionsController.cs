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
    [Route("api/Decisions")]
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
        [HttpGet]
        public async Task<IEnumerable<Decision>> Get()
        {
            try
            {

                return await repository.GetAll().Select(selector).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // GET: api/Decisions/5
        [HttpGet("{id}", Name = "GetDecisions")]
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

        // POST: api/Decisions
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Decisions/5
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
