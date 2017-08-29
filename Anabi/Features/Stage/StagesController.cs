using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Controllers;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Stage
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StagesController : BaseController
    {
        private readonly IGenericRepository<StageDb> repository;
        public StagesController(IGenericRepository<StageDb> repo)
        {
            repository = repo;
        }

        System.Linq.Expressions.Expression<Func<StageDb, Domain.Models.Stage>> selector = c => new Domain.Models.Stage()
        {
            Name = c.Name,
            Id = c.Id,
            IsFinala = c.IsFinal
        };

        // GET: api/Stages
        [HttpGet]
        public async Task<IEnumerable<Domain.Models.Stage>> Get()
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

        // GET: api/Stages/5
        [HttpGet("{id}")]
        public async Task<Domain.Models.Stage> Get(int id)
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

        // POST: api/Stages
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stages/5
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
