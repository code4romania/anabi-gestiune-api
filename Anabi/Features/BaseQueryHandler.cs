using Anabi.DataAccess.Ef;
using AutoMapper;

namespace Anabi.Features
{
    public class BaseQueryHandler
    {
        public AnabiContext context { get; private set; } 
        public IMapper mapper { get; private set; }

        public BaseQueryHandler(AnabiContext _ctx, IMapper _mapper)
        {
            context = _ctx;
            mapper = _mapper;
        }
    }
}
