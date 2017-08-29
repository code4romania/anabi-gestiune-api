using Anabi.DataAccess.Ef;
using AutoMapper;

namespace Anabi.Domain
{
    public class BaseHandler
    {
        public AnabiContext context { get; private set; } 
        public IMapper mapper { get; private set; }

        public BaseHandler(AnabiContext _ctx, IMapper _mapper)
        {
            context = _ctx;
            mapper = _mapper;
        }
    }
}
