using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Dictionaries.Category
{
    public class AddCategoryQuery : IRequest
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public string ForEntity { get; set; }
    }


    public class AddCategoryQueryValidator : AbstractValidator<AddCategoryQuery>
    {
        public AddCategoryQueryValidator()
        {
            RuleFor(c => c.Id).Equal(0);
            RuleFor(c => c.Code).NotEmpty().WithMessage("Codul este obligatoriu!");
            RuleFor(c => c.Code).Length(1, 100).WithMessage("Codul trebuie sa aiba lungimea de 1 pana la 100 de caractere!");
            RuleFor(c => c.Description).Length(0, 4000).WithMessage("Descrierea nu poate avea mai mult de 4000 de caractere!");
            RuleFor(c => c.ForEntity).Length(1, 40).WithMessage("\"Pentru entitate\" trebuie sa contina o valoare de maxim 40 de caractere!");

        }
    }
}
