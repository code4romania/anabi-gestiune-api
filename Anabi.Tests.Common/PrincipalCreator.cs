using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace Anabi.Tests.Common
{
    public class PrincipalCreator
    {
        public static IPrincipal TestAuthentificatedPrincipal()
        {
            IEnumerable<Claim> claims
                = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "test"),
                    new Claim(ClaimTypes.Email, "test@test.com"),
                    new Claim(ClaimTypes.Role, "Admin")

                };


            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Basic"));
            var isAuthenticated = principal.Identity.IsAuthenticated; // true
            return principal;

        }
    }
}
