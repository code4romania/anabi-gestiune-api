using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Controllers;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain;
using Anabi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Institution
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InstitutionsController : BaseController
    {
        private readonly IGenericRepository<InstitutionDb> repository;
        public InstitutionsController(IGenericRepository<InstitutionDb> repo)
        {
            repository = repo;
        }

        System.Linq.Expressions.Expression<Func<InstitutionDb, Institution>> selector = c => new Institution()
        {
            Id = c.Id,
            Category = (c.Category != null) ? new Category.Models.Category()
            {
                Code = c.Category.Code,
                Description = c.Category.Description,
                ForEntity = c.Category.ForEntity,
                Id = c.Id,
                Parent = (c.Category.Parent != null) ? new Category.Models.Category()
                {
                    Id = c.Category.Parent.Id,
                    Code = c.Category.Parent.Code,
                    Description = c.Category.Parent.Description,
                    ForEntity = c.Category.Parent.ForEntity,
                    ParentId = c.Category.Parent.Id
                } : null,
                ParentId = c.Category.ParentId
            } : null,

            Name = c.Name,
            Address = (c.Address != null) ? new Address()
            {
                Id = c.Address.Id,
                CountyId = c.Address.CountyId,
                County = (c.Address.County != null) ? new County()
                {
                    Id = c.Address.County.Id,
                    Name = c.Address.County.Name,
                    Abreviation = c.Address.County.Abreviation
                } : null,
                Street = c.Address.Street,
                City = c.Address.City,
                Building = c.Address.Building,
                Stair = c.Address.Stair,
                Floor = c.Address.Floor,
                FlatNo = c.Address.FlatNo
            } : null
            // Missing?!
            //Journal = (c.Journal!=null)
            //UserCodeAdd
            //UserCodeLastChange
            //AddedDate
            //LastChangeDate
        };


        // GET: api/Institutions
        [HttpGet]
        public async Task<IEnumerable<Institution>> Get()
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

        // GET: api/Institutions/5
        [HttpGet("{id}")]
        public async Task<Institution> Get(int id)
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

        // POST: api/Institutions
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Institutions/5
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
