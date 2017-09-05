using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Domain.Category.Commands
{
    public class DeleteCategory : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryValidator : AbstractValidator<DeleteCategory>
    {
        private readonly AnabiContext context;
        public DeleteCategoryValidator(AnabiContext ctx)
        {
            //TODO Aici ar fi trebuit sa se foloseasca resources la nivel de domeniu
            context = ctx;
            RuleFor(m => m.Id).GreaterThan(0).WithMessage("Id-ul nu a fost specificat!");
            RuleFor(m => m).MustAsync(HaveNoChildren).WithMessage("Categoria nu poate fi stearsa deoarce exista inregistrari care o referentiaza!");
        }

        private async Task<bool> HaveNoChildren(DeleteCategory query, CancellationToken arg2)
        {
            var hasNoChildren = false;

            var category = await context.Categorii.FirstAsync(c => c.Id == query.Id);

            hasNoChildren = (
                     (!(category.Children == null ? false : category.Children.Any())) &&
                     (!(category.Assets == null ? false : category.Assets.Any() )) &&
                     (!(category.Institutions == null ? false : category.Institutions.Any() ))
                     );
                     

            return hasNoChildren;
        }
    }
}
