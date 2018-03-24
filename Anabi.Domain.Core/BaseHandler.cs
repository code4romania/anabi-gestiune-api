using Anabi.DataAccess.Ef;
using AutoMapper;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Anabi.Domain
{
    public class BaseHandler
    {
        private readonly IPrincipal principal;

        public AnabiContext context { get; private set; } 
        public IMapper mapper { get; private set; }


        public BaseHandler(BaseHandlerNeeds needs)
        {
            context = needs.DbContext;
            mapper = needs.Mapper;
            principal = needs.Principal;
        }

        protected string UserCode()
        {
            var p = principal as ClaimsPrincipal;
            if (p == null)
            {
                return null;
            }

            return p.Claims?.SingleOrDefault(c =>
                    c.Type == ClaimTypes.NameIdentifier)
                .Value;
        }
    }
}
