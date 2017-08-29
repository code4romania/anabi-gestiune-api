using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Controllers;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.RecoveryBeneficiary
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RecoveryBeneficiariesController : BaseController
    {
        private readonly IGenericRepository<RecoveryBeneficiaryDb> repository;
        public RecoveryBeneficiariesController(IGenericRepository<RecoveryBeneficiaryDb> repo)
        {
            repository = repo;
        }

        System.Linq.Expressions.Expression<Func<RecoveryBeneficiaryDb, Domain.Models.RecoveryBeneficiary>> selector = c => new Domain.Models.RecoveryBeneficiary()
        {
            Id = c.Id,
            Name = c.Name            
        };

        // GET: api/RecoveryBeneficiaries
        [HttpGet]
        public async Task<IEnumerable<Domain.Models.RecoveryBeneficiary>> Get()
        {
                return await repository.GetAll().Select(selector).ToListAsync();
        }

        // GET: api/RecoveryBeneficiaries/5
        [HttpGet("{id}")]
        public async Task<Domain.Models.RecoveryBeneficiary> Get(int id)
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