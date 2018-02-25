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
        public CategoryHandler(BaseHandlerNeeds needs) : base(needs)
        {

        }

        public async Task<int> Handle(AddCategory message)
        {
            var newCategory = new CategoryDb();
            
            Mapper.Map(message, newCategory);
            
            context.Categories.Add(newCategory);

            await context.SaveChangesAsync();

            return newCategory.Id;
        }

        public async Task Handle(DeleteCategory message)
        {
            var categoryToDelete = await context.Categories.FirstAsync(c => c.Id == message.Id);
            context.Categories.Remove(categoryToDelete);
            await context.SaveChangesAsync();
        }

        public async Task Handle(EditCategory message)
        {

            var categoryToEdit = await this.context.Categories.Where(p => p.Id == message.Id).FirstAsync();

            Mapper.Map(message, categoryToEdit);

            await context.SaveChangesAsync();

        }
    }
}
