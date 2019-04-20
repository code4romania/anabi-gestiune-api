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


    public class AddInstitution : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class AddInstitutionValidator : AbstractValidator<AddInstitution>
    {
        public AddInstitutionValidator(AnabiContext context,
            IDatabaseChecks checks, AbstractValidator<IAddAddress> addAddressValidator)
        {
            RuleFor(p => p.Name).Length(1, 50).WithMessage("Numele poate avea o lungime de 1-50 caractere");
        }
    }
}
