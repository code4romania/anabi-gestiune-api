using System;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Dictionaries.Category
{
    public class DeleteCategoryHandler : BaseHandler, IAsyncRequestHandler<DeleteCategory>
    {
        public DeleteCategoryHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task Handle(DeleteCategory message)
        {
            var categoryToDelete = await context.Categorii.FirstAsync(c => c.Id == message.Id);
            context.Categorii.Remove(categoryToDelete);
            await context.SaveChangesAsync();
        }
    }
}
