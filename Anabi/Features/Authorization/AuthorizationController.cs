using Anabi.Controllers;
using Anabi.Domain.Models;
using Anabi.Features.Authorization.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Anabi.Features.Authorization
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorizationController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IConfiguration _config;

        public AuthorizationController(IMediator mediator, IConfiguration config)
        {
            _mediator   = mediator;
            _config     = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticationRequest request)
        {
            Anabi.Domain.Models.User user = await _mediator.Send(request);

            if (user == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("role", user.Role)
            };

            var key     = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds   = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

    }
}
