using Anabi.DataAccess.Ef;
using Anabi.Domain;
using Anabi.Domain.Models;
using Anabi.Features.Authorization.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Security;

namespace Anabi.Features.Authorization
{
    public class AuthorizationQueryHandler : BaseHandler, IAsyncRequestHandler<AuthenticationRequest, Anabi.Domain.Models.User>
    {
        private readonly IAnabiCrypt _crypt;

        public AuthorizationQueryHandler(BaseHandlerNeeds needs, IAnabiCrypt crypt) : base(needs)
        {
            _crypt = crypt;
        }

        public async Task<Anabi.Domain.Models.User> Handle(AuthenticationRequest request)
        {
            var foundUser = await context.Users.SingleOrDefaultAsync(u => u.UserCode == request.Username);

            if (foundUser == null)
            {
                return null;
            }
            if (foundUser.IsActive == false)
            {
                return null;
            }
            if (_crypt.IsHashCorrespondingToValue(foundUser.Password, request.Password))
            {
                return Mapper.Map<Anabi.Domain.Models.User>(foundUser);
            }

        }
    }
}
