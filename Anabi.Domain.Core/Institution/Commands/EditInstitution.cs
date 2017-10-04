using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Institution.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using Anabi.DataAccess.Ef;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public class EditInstitution : IRequest 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int? AddressId { get; set; }

        public string ChangeByUserCode { get; set; }
    }

    public class EditInstitutionValidator : AbstractValidator<EditInstitution>
    {
        private readonly AnabiContext context;
        public EditInstitutionValidator(AnabiContext context)
        {
            this.context = context;

            RuleFor(m => m.Id).GreaterThan(0);

            RuleFor(m => m.ChangeByUserCode).MustAsync(UserExists).WithMessage("Utilizatorul nu exista");
        }

        private async Task<bool> UserExists(string userCode, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(userCode) || userCode.Length > 20)
            {
                return false;
            }

            return await this.context.Utilizatori.AnyAsync(x => x.UserCode == userCode, cancellationToken);
        }
    }
}
