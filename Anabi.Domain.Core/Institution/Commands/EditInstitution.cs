using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Anabi.Domain.Common;
using Anabi.Domain.Common.Address;

namespace Anabi.Domain.Institution.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using Anabi.DataAccess.Ef;

    using FluentValidation;

    public class EditInstitution : IAddAddress, IRequest 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string ChangeByUserCode { get; set; }

        public string CountyCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Building { get; set; }

        public string Stair { get; set; }

        public string Floor { get; set; }

        public string FlatNo { get; set; }
    }

    public class EditInstitutionValidator : AbstractValidator<EditInstitution>
    {
        public EditInstitutionValidator(AnabiContext context,
            IDatabaseChecks checks, AbstractValidator<IAddAddress> addAddressValidator)
        {
            RuleFor(m => m.Id).GreaterThan(0);

            RuleFor(m => m.ChangeByUserCode).MustAsync(
                checks.UserExists).WithMessage("Utilizatorul nu exista");

            RuleFor(m => m).SetValidator(addAddressValidator).Unless(m => checks.EmptyAddress(m));
        }
    }
}
