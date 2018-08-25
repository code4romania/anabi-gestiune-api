using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anabi.Domain;
using Anabi.Features.Category.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Category
{
    public class CategoryQueryHandler : BaseHandler, IRequestHandler<GetCategory, List<Models.Category>>
    {
        public CategoryQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<List<Models.Category>> Handle(GetCategory message, CancellationToken cancellationToken)
        {

            var command = context.Categories.AsQueryable();

            if (message.Id != null)
            {
                command = command.Where(m => m.Id == message.Id);
            }

            var result = await command.Select(x => Mapper.Map<Models.Category>(x)).ToListAsync(cancellationToken);
            return result;
        }
    }
}
