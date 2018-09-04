using System.Security.Principal;
using Anabi.DataAccess.Ef;
using AutoMapper;

namespace Anabi.Domain
{
    public class BaseHandlerNeeds
    {
        public AnabiContext DbContext { get; }
        public IMapper Mapper { get; }
        public IPrincipal Principal { get; }

        public BaseHandlerNeeds(AnabiContext dbContext, IMapper mapper, IPrincipal principal)
        {
            DbContext = dbContext;
            Mapper = mapper;
            Principal = principal;
        }
    }
}
