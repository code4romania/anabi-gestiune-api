namespace Anabi.Domain.Institution.Commands
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Anabi.DataAccess.Ef;
    using Anabi.Validators.Extensions;
    using FluentValidation;

    using MediatR;

    public class DeleteInstitution : IRequest
   {
        public int Id { get; set; }
    }

    public class DeleteInstitutionValidator : AbstractValidator<DeleteInstitution>
    {
        private readonly AnabiContext context;

        public DeleteInstitutionValidator(AnabiContext context)
        {
            this.context = context;
        
            RuleFor(m => m.Id).MustBeInDbSet(context.Institutions).WithMessage("Id-ul nu a fost specificat!");
            RuleFor(m => m).MustAsync(AreNoOtherUsages);
        }

        private async Task<bool> AreNoOtherUsages(DeleteInstitution deleting, CancellationToken cancellationToken)
        {
            var data = await this.context.Institutions.
                FindAsync(new object[] { deleting.Id }, cancellationToken);
            bool isUsed = (data.HistoricalStages != null && data.HistoricalStages.Any());

            return isUsed == false;
        }
    }
}
