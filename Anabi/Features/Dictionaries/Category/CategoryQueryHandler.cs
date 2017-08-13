using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xModel = Anabi.Domain.Core.Models;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Dictionaries.Category
{
    public class CategoryQueryHandler : BaseQueryHandler, IAsyncRequestHandler<CategoryQuery, List<xModel.Category>>
    {
        
        public CategoryQueryHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
            
        }

        public Task<List<xModel.Category>> Handle(CategoryQuery message)
        {

            var command = context.Categorii.AsQueryable();

            if (message.Id != null)
            {
                command = command.Where(m => m.Id == message.Id);
            }

            var result = command.Select(x => Mapper.Map<xModel.Category>(x)).ToListAsync();
            return result;
        }
    }
}
