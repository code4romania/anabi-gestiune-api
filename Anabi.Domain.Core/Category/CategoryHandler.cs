using System.Linq;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Category.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Domain.Category
{
    public class CategoryHandler : BaseHandler
        , IAsyncRequestHandler<AddCategory, int>
        , IAsyncRequestHandler<DeleteCategory>
        , IAsyncRequestHandler<EditCategory>
    {
        public CategoryHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {

        }

        public async Task<int> Handle(AddCategory message)
        {
            var newCategory = new CategoryDb();
            
            Mapper.Map(message, newCategory);
            
            context.Categorii.Add(newCategory);

            await context.SaveChangesAsync();

            return newCategory.Id;
        }

        public async Task Handle(DeleteCategory message)
        {
            var categoryToDelete = await context.Categorii.FirstAsync(c => c.Id == message.Id);
            context.Categorii.Remove(categoryToDelete);
            await context.SaveChangesAsync();
        }

        public async Task Handle(EditCategory message)
        {

            var categoryToEdit = await this.context.Categorii.Where(p => p.Id == message.Id).FirstAsync();

            Mapper.Map(message, categoryToEdit);

            await context.SaveChangesAsync();

        }
    }
}
