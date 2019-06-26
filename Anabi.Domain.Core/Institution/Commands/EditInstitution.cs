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

    public class EditInstitution : IRequest 
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class EditInstitutionValidator : AbstractValidator<EditInstitution>
    {
        public EditInstitutionValidator(AnabiContext context,
            IDatabaseChecks checks, AbstractValidator<IAddAddress> addAddressValidator)
        {
            RuleFor(m => m.Id).GreaterThan(0);
        }
    }
}
