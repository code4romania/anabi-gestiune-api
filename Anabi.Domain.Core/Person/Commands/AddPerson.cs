using Anabi.Common.Utils;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Person.Commands
{
    public class AddPerson : IRequest<int>
    {
        public string IdNumber { get; set; }

        public string IdSerie { get; set; }

        public string Identification { get; set; }

        public bool IsPerson { get; set; }

        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }

        public string FirstName { get; set; }

        public int IdentifierId { get; set; }

        public string Nationality { get; set; }

    }

    
    public class AddPersonValidator : AbstractValidator<AddPerson>
    {
        private readonly AnabiContext context;

        public AddPersonValidator(AnabiContext ctx)
        {
            context = ctx;

            RuleFor(p => p.IdNumber).MaximumLength(6).WithMessage(Constants.IDNUMBER_MAX_LENGTH_6);
            RuleFor(p => p.IdSerie).MaximumLength(2).WithMessage(Constants.IDSERIE_MAX_LENGTH_2);

            RuleFor(p => p.Identification).MaximumLength(20).WithMessage(Constants.IDENTIFICATION_MAX_LENGTH_20);
            RuleFor(p => p.Identification).NotEmpty().WithMessage(Constants.IDENTIFICATION_CANNOT_BE_EMPTY);

            RuleFor(p => p.Name).MaximumLength(200).WithMessage(Constants.PERSONNAME_MAX_LENGTH_200);
            RuleFor(p => p.Name).NotEmpty().WithMessage(Constants.PERSONNAME_CANNOT_BE_EMPTY);

            RuleFor(p => p.FirstName).MaximumLength(50).WithMessage(Constants.FIRSTNAME_MAX_LENGTH_50);
            RuleFor(p => p.Nationality).MaximumLength(20).WithMessage(Constants.NATIONALITY_MAX_LENGTH_20);

            RuleFor(p => p.Identification).MustAsync(NotExist).WithMessage(Constants.PERSONIDENTIFICATION_ALREADY_EXISTS);

        }

        private async Task<bool> NotExist(string identification, CancellationToken cancellationToken)
        {
            var identificationExists = await context.Persons.AnyAsync(x => x.Identification == identification);
            return !identificationExists;
        }

    }
}
