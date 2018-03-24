using System;
namespace Anabi.Features.Institution.Models
{
    using Anabi.Common.Utils;
    using FluentValidation;
    using MediatR;
    using System.Collections.Generic;

    public class GetInstitution : IRequest<List<Institution>>
    {
        public int? Id { get; set; }
    }

    public class GetInstitutionValidator : AbstractValidator<GetInstitution>
    {
        public GetInstitutionValidator()
        {
            RuleFor(p => p.Id).Must(HaveValidValue).WithMessage(Constants.INVALID_ID);
        }

        private bool HaveValidValue(int? arg)
        {
            if (arg != null)
            {
                if (arg <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
