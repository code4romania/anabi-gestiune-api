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
    [Route("api/Inculpati")]
    public class InculpatiController : Controller
    {
        private IInculpatiRepository repository;
        public InculpatiController(IInculpatiRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Persoana>> Get()
        {
            var resp = await repository.GetInculpatiAsync();
            return resp;

        }

        [HttpGet("{filtru}", Name = "InculpatiFiltrati")]
        public async Task<IEnumerable<Persoana>> InculpatiFiltrati(string filtru)
        {
            var resp = await repository.GetInculpatiFiltratiAsync(filtru);
            return resp;

        }
    }
}