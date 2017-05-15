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
    [Route("api/Bunuri")]
    public class BunuriController : Controller
    {
        private readonly IBunuriRepository repository;
        public BunuriController(IBunuriRepository repo)
        {
            repository = repo;
        }


        [HttpGet]
        public async Task<IEnumerable<Bun>> Get()
        {
            var lst = await repository.GetBunuriAsync();

            return lst;
        }
    }
}