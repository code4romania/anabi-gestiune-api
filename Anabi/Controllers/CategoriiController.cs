using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Anabi.DataAccess.Abstractions.Repositories;
using Anabi.Domain.Core.Models;
using Anabi.Domain.Core;

namespace Anabi.Controllers
{
    [Produces("application/json")]
    [Route("api/Categorii")]
    public class CategoriiController : Controller
    {
        //private readonly ICategoriiRepository repository;

        //public CategoriiController(ICategoriiRepository repo )
        //{
        //    repository = repo;
        //}

        //[HttpGet]
        //public async Task<IEnumerable<Category>> Get()
        //{
        //    var resp = await repository.GetCategoriiAsync();
        //    return resp;

        //}

        //[HttpGet("{filtru}", Name = "CategoriiFiltrate")]
        //public async Task<IEnumerable<Category>> CategoriiFiltrate(string filtru)
        //{
        //    var resp = await repository.GetCategoriiFiltrateAsync(filtru);
        //    return resp;

        //}

    }
}