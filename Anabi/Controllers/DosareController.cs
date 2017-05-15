using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Anabi.Abstractions;
using Anabi.Domain.Core;
using System.Net;
using Anabi.DataAccess.Abstractions.Repositories;
using Anabi.Domain.Core.Models;

namespace Anabi.Controllers
{
    [Produces("application/json")]
    [Route("api/Dosare")]
    public class DosareController : Controller
    {
        private readonly IDosareRepository repository;
        public DosareController(IDosareRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Dosar>> Get()
        {
            var lst = await repository.GetDosareAsync();

            return lst;
        }

        [HttpPost]
        public IActionResult Post(string value)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}