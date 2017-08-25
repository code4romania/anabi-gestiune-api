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
    public class EditCategoryHandler : BaseHandler, IAsyncRequestHandler<EditCategory>
    {
        public EditCategoryHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task Handle(EditCategory message)
        {

            var categoryToEdit = await this.context.Categorii.Where(p => p.Id == message.Id).FirstAsync();

            Mapper.Map(message, categoryToEdit);

            await context.SaveChangesAsync();

        }
    }
}
