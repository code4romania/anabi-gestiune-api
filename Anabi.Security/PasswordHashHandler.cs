using Anabi.Security.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anabi.Security
{
    public class PasswordHashHandler : IAsyncRequestHandler<GetPasswordHash, string>
        ,IAsyncRequestHandler<GetPasswordEquality, bool>
    {
        public Task<string> Handle(GetPasswordHash message)
        {

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(message.Password);

            return Task.FromResult(passwordHash);
        }

        public Task<bool> Handle(GetPasswordEquality message)
        {
            var result = BCrypt.Net.BCrypt.Verify(message.ClearPassword, message.HashedPassword);

            return Task.FromResult(result);
        }
    }
}
