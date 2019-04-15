using System;
using System.Threading;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Category.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Domain.Category
{
    public class CategoryHandler : BaseHandler
        , IRequestHandler<AddCategory, int>
        , IRequestHandler<DeleteCategory>
        , IRequestHandler<EditCategory>
    {
        public CategoryHandler(BaseHandlerNeeds needs) : base(needs)
        {

        }

        public async Task<int> Handle(AddCategory message, CancellationToken cancellationToken)
        {
            var newCategory = new CategoryDb();
            
            mapper.Map(message, newCategory);
            newCategory.UserCodeAdd = UserCode();
            
            context.Categories.Add(newCategory);

            await context.SaveChangesAsync();

            return newCategory.Id;
        }

        public async Task<Unit> Handle(DeleteCategory message, CancellationToken cancellationToken)
        {
            var categoryToDelete = await context.Categories.FirstAsync(c => c.Id == message.Id);
            context.Categories.Remove(categoryToDelete);
            await context.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(EditCategory message, CancellationToken cancellationToken)
        {

            var categoryToEdit = await this.context.Categories.FindAsync(message.Id);

            mapper.Map(message, categoryToEdit);
            categoryToEdit.UserCodeLastChange = UserCode();
            categoryToEdit.LastChangeDate = DateTime.Now;

            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
