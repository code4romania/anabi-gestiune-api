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
    [Route("api/StorageSpaces")]
    public class StorageSpacesController : BaseController
    {
        private readonly IGenericRepository<StorageSpaceDb> repository;
        public StorageSpacesController(IGenericRepository<StorageSpaceDb> repo)
        {
            repository = repo;
        }

        System.Linq.Expressions.Expression<Func<StorageSpaceDb, StorageSpace>> selector = c => new StorageSpace()
        {
            Name = c.Name,
            Id = c.Id,
            Address = (c.Address != null) ? new Address()
            {
                Id = c.Address.Id,
                CountyId = c.Address.CountyId,
                County = (c.Address.County!=null) ? new County() {
                    Id=c.Address.County.Id,
                    Name=c.Address.County.Name,
                    Abreviation=c.Address.County.Abreviation
                }:null,
                Street = c.Address.Street,
                City = c.Address.City,
                Building = c.Address.Building,
                Stair = c.Address.Stair,
                Floor = c.Address.Floor,
                FlatNo = c.Address.FlatNo
            } : null
        };

        // GET: api/Categories
        [HttpGet]
        public async Task<IEnumerable<StorageSpace>> Get()
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
        [HttpGet("{id}", Name = "GetStorageSpaceById")]
        public async Task<StorageSpace> Get(int id)
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
