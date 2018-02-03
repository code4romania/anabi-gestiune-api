using Anabi.Domain.Models;
using MediatR;

namespace Anabi.Features.Authorization.Models
{
    public class AuthenticationRequest : IRequest<Anabi.Domain.Models.User>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
