using Anabi.DataAccess.Ef;
using Anabi.Domain;
using Anabi.Domain.Models;
using Anabi.Features.Authorization.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Authorization
{
    public class AuthorizationQueryHandler : BaseHandler, IAsyncRequestHandler<AuthenticationRequest, Anabi.Domain.Models.User>
    {
        public AuthorizationQueryHandler(AnabiContext _context, IMapper _mapper) : base(_context, _mapper)
        {
            
        }

        public async Task<Anabi.Domain.Models.User> Handle(AuthenticationRequest request)
        {
            return await context.Utilizatori
                .AsQueryable()
                .Where(u => u.UserCode == request.Username && u.Password == request.Password && u.IsActive == true)
                .Select(u => Mapper.Map<Anabi.Domain.Models.User>(u))
                .FirstOrDefaultAsync();

        }
    }
}
