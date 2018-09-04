using Anabi.Security.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Security
{
    public class PasswordHashHandler : IRequestHandler<GetPasswordHash, string>
        ,IRequestHandler<GetPasswordEquality, bool>
    {
        public Task<string> Handle(GetPasswordHash message, CancellationToken cancellationToken)
        {

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(message.Password);

            return Task.FromResult(passwordHash);
        }

        public Task<bool> Handle(GetPasswordEquality message, CancellationToken cancellationToken)
        {
            var result = BCrypt.Net.BCrypt.Verify(message.ClearPassword, message.HashedPassword);

            return Task.FromResult(result);
        }
    }
}
