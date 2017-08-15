using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Anabi.DataAccess.Ef;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Dictionaries.Category
{
    public class DeleteCategoryQuery : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryQueryValidator : AbstractValidator<DeleteCategoryQuery>
    {
        private readonly AnabiContext context;
        public DeleteCategoryQueryValidator(AnabiContext ctx)
        {
            context = ctx;
            RuleFor(m => m.Id).GreaterThan(0).WithMessage("Id-ul nu a fost specificat!");
            RuleFor(m => m).MustAsync(HaveNoChildren).WithMessage("Categoria nu poate fi stearsa deoarce exista inregistrari care o referentiaza!");
        }

        private async Task<bool> HaveNoChildren(DeleteCategoryQuery query, CancellationToken arg2)
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
