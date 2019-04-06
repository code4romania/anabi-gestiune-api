using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MediatR;

namespace Anabi.Domain.Common.Address
{
    public class AddMinimalAddress : IAddMinimalAddress
    {
        public string CountyCode { get; set; }
        public string City { get ; set ; }
        public string Street { get ; set ; }
        public string Building { get; set; }
        public string Details { get; set; }
    }

    public class AddMinimalAddressValidator : AbstractValidator<IAddMinimalAddress>
    {
        private readonly IDatabaseChecks checks;
        public AddMinimalAddressValidator(IDatabaseChecks checks)
        {
            this.checks = checks;
            AddRules();
        }

        public void AddRules()
        {
            RuleFor(m => m.CountyCode).NotEmpty().Length(1, 2).WithMessage("INVALID_COUNTY_CODE_MIN_1_MAX_2");
            RuleFor(m => m.City).NotEmpty().Length(1, 30).WithMessage("INVALID_CITY");           
            RuleFor(m => m.Street).MaximumLength(100).Length(1, 100).WithMessage("STREET_NAME_TOO_LONG_MAX_100");
            RuleFor(m => m.Building).MaximumLength(30).WithMessage("BUILDING_TOO_LONG_MAX_30");
            RuleFor(m => m.Details).MaximumLength(300).Length(1, 300).WithMessage("DESCRIPTION_TOO_LONG_MAX_300");
            RuleFor(m => m.CountyCode).MustAsync(checks.CountyExists).WithMessage("INVALID_COUNTY_CODE");
        }
    }
}
