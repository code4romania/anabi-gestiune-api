using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Dictionaries.Category
{
    public class EditCategoryQueryHandler : BaseQueryHandler, IAsyncRequestHandler<EditCategoryQuery>
    {
        public EditCategoryQueryHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task Handle(EditCategoryQuery message)
        {

            var categoryToEdit = await this.context.Categorii.Where(p => p.Id == message.Id).FirstAsync();

            Mapper.Map(message, categoryToEdit);

            await context.SaveChangesAsync();

        }
    }
}
