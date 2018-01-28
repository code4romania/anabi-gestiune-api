using Anabi.Domain.Enums;
using Anabi.Domain.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Anabi.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Base")]
    public class BaseController : Controller
    {
        public AnabiPrincipal Principal
        {
            get
            {
                if (HttpContext == null || HttpContext.User == null || !HttpContext.User.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    return null;
                }

                var claimsPrincipal = HttpContext.User;

                return new AnabiPrincipal
                {
                    Email   = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    Role    = (UserRole)Enum.Parse(typeof(UserRole), claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value)
                };
            }
        }
    }
}