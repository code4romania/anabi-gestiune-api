using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Institution.Commands
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Anabi.DataAccess.Ef;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public class AddInstitution : IRequest
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int? AddressId { get; set; }

        public string UserCodeAdd { get; set; }
    }

    public class AddInstitutionValidator : AbstractValidator<AddInstitution>
    {
        private readonly AnabiContext context;

        public AddInstitutionValidator(AnabiContext context)
        {
            this.context = context;
            RuleFor(m => m.CategoryId).NotEmpty();

            RuleFor(p => p.Name).Length(1, 50).WithMessage("Numele poate avea o lungime de 1-50 caractere");
            
            RuleFor(m => m.UserCodeAdd).MustAsync(UserExists).WithMessage("Utilizatorul nu exista");
        }

        private async Task<bool> UserExists(string userCode, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(userCode) || userCode.Length > 20)
            {
                return false;
            }

            return await this.context.Utilizatori.AnyAsync(x=> x.UserCode == userCode, cancellationToken);
        }
    }
}
