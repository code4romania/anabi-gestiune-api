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
    [Route("api/Stages")]
    public class StagesController : BaseController
    {
        private readonly IGenericRepository<StageDb> repository;
        public StagesController(IGenericRepository<StageDb> repo)
        {
            repository = repo;
        }

        System.Linq.Expressions.Expression<Func<StageDb, Stage>> selector = c => new Stage()
        {
            Name = c.Name,
            Id = c.Id,
            IsFinala = c.IsFinal
        };

        // GET: api/Stages
        [HttpGet]
        public async Task<IEnumerable<Stage>> Get()
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
        [HttpGet("{id}", Name = "GetStageById")]
        public async Task<Stage> Get(int id)
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
