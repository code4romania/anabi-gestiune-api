using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Anabi.DataAccess.Abstractions.Repositories;
using Anabi.Domain.Core.Models;

namespace Anabi.Controllers
{
    [Produces("application/json")]
    [Route("api/Judete")]
    public class JudeteController : Controller
    {
        private readonly IJudetRepository repository;

        public JudeteController(IJudetRepository repo)
        {
            repository = repo;
        }

        // GET: api/Judete
        [HttpGet]
        public async Task<IEnumerable<Judet>> Get()
        {
            var judete = await repository.GetJudeteAsync();
            return judete;
        }

        // GET: api/Judete/5
        [HttpGet("{filtru}", Name = "JudeteFiltrate")]
        public async Task<IEnumerable<Judet>> JudeteFiltrate(string filtru)
        {
            var judete = await repository.GetJudeteFiltrateAsync(filtru);
            return judete;
        }
        
        // POST: api/Judete
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Judete/5
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
