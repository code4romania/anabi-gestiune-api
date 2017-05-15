using Anabi.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Anabi.Abstractions
{
    public interface IDosareController
    {
        

        IActionResult Post(string value);
    }
}
