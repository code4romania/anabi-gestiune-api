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
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly IGenericRepository<CategoryDb> repository;
        public CategoriesController(IGenericRepository<CategoryDb> repo)
        {
            repository = repo;
        }

        System.Linq.Expressions.Expression<Func<CategoryDb, Category>> selector = c => new Category()
        {
            Code = c.Code,
            Description = c.Description,
            ForEntity = c.ForEntity,
            Id = c.Id,
            Parent = (c.Parent != null) ? new Category() { Id = c.Parent.Id, Code = c.Parent.Code, Description = c.Parent.Description, ForEntity = c.Parent.ForEntity, ParentId = c.Parent.Id } : null,
            ParentId = c.ParentId
        };

        // GET: api/Categories
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
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

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Category> Get(int id)
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
        
        // POST: api/Categories
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Categories/5
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
