using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Anabi.Abstractions;

namespace Anabi.Controllers
{
    [Produces("application/json")]
    [Route("api/Cautare")]
    public class CautareController : Controller, ICautareController
    {

    }
}