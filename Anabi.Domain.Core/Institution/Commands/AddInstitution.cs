using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Anabi.Domain.Common;
using Anabi.Domain.Common.Address;

namespace Anabi.Domain.Institution.Commands
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Anabi.DataAccess.Ef;

    using FluentValidation;


    public class AddInstitution : IAddAddress, IRequest<int>
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string UserCodeAdd { get; set; }

        public string CountyCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Building { get; set; }

        public string Stair { get; set; }

        public string Floor { get; set; }

        public string FlatNo { get; set; }
    }

    public class AddInstitutionValidator : AbstractValidator<AddInstitution>
    {
        public AddInstitutionValidator(AnabiContext context,
            IDatabaseChecks checks, AbstractValidator<IAddAddress> addAddressValidator)
        {
            RuleFor(m => m.CategoryId).NotEmpty();

            RuleFor(p => p.Name).Length(1, 50).WithMessage("Numele poate avea o lungime de 1-50 caractere");

            RuleFor(m => m.UserCodeAdd).MustAsync(
                checks.UserExists).WithMessage("Utilizatorul nu exista");

            RuleFor(m => m).SetValidator(addAddressValidator).Unless(m=> checks.EmptyAddress(m));
        }
    }
}
