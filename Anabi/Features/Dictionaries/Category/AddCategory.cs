using FluentValidation;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Anabi.DataAccess.Ef;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Features.Dictionaries.Category
{
    public class AddCategory : IRequest
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public string ForEntity { get; set; }
    }


    public class AddCategoryValidator : AbstractValidator<AddCategory>
    {
        private readonly AnabiContext context;

        public AddCategoryValidator(AnabiContext ctx)
        {
            context = ctx;
            RuleFor(c => c.Id).Equal(0);
            RuleFor(c => c.Code).NotEmpty().WithMessage("Codul este obligatoriu!");
            RuleFor(c => c.Code).Length(1, 100).WithMessage("Codul trebuie sa aiba lungimea de 1 pana la 100 de caractere!");
            RuleFor(c => c.Description).Length(0, 4000).WithMessage("Descrierea nu poate avea mai mult de 4000 de caractere!");
            RuleFor(c => c.ForEntity).Length(1, 40).WithMessage("\"Pentru entitate\" trebuie sa contina o valoare de maxim 40 de caractere!");
            RuleFor(c => c.Code).MustAsync(HaveUniqueCode).WithMessage("Codul exista la o alta categorie!");
        }

        private async Task<bool> HaveUniqueCode(string arg1, CancellationToken arg2)
        {
            var codeExists = await context.Categorii.AnyAsync(c => c.Code == arg1);
            return !codeExists;

        }
    }
}
