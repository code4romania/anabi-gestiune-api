using MediatR;

namespace Anabi.Domain.Institution.Commands
{
    using Anabi.Common.Utils;
    using Anabi.DataAccess.Ef;
    using Anabi.Validators.Extensions;
    using FluentValidation;

    public class EditInstitution : IRequest 
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class EditInstitutionValidator : AbstractValidator<EditInstitution>
    {
        public EditInstitutionValidator(AnabiContext context)
        {
            RuleFor(m => m.Id).MustBeInDbSet(context.Assets).WithMessage(Constants.INSTITUTION_INVALID_ID);
        }
    }
}
