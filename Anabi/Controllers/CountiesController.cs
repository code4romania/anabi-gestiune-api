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
    public class CountiesController : BaseController
    {
        private readonly IGenericRepository<CountyDb> repository;
        public CountiesController(IGenericRepository<CountyDb> repo)
        {
            repository = repo;
        }

        System.Linq.Expressions.Expression<Func<CountyDb, County>> selector = c => new County()
        {
            Name = c.Name,
            Id = c.Id,
            Abreviation = c.Abreviation
        };

        // GET: api/Counties
        [HttpGet]
        public async Task<IEnumerable<County>> Get()
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

        // GET: api/Counties/5
        [HttpGet("{id}")]
        public async Task<County> Get(int id)
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

        // POST: api/Counties
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Counties/5
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
