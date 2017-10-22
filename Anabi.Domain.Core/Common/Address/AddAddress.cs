using System;
using System.Collections.Generic;
using System.Linq;
using Anabi.DataAccess.Ef.DbModels;
using FluentValidation;

namespace Anabi.Domain.Common.Address
{
    public class AddAddress : IAddAddress
    {
        public string CountyCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Stair { get; set; }
        public string Floor { get; set; }
        public string FlatNo { get; set; }
    }

    public class EmptyAddAddressValidator : AbstractValidator<IAddAddress>
    {
        public EmptyAddAddressValidator()
        {
            RuleFor(m => m.CountyCode).Empty();
            RuleFor(m => m.City).Empty();
            RuleFor(m => m.Street).Empty();
            RuleFor(m => m.Building).Empty();
            RuleFor(m => m.Stair).Empty();
            RuleFor(m => m.Floor).Empty();
            RuleFor(m => m.FlatNo).Empty();
        }
    }

    public class AddAddressValidator : AbstractValidator<IAddAddress>
    {
        private readonly IDatabaseChecks checks;
        public AddAddressValidator(IDatabaseChecks checks)
        {
            this.checks = checks;
           AddRules();
        }

        public void AddRules()
        {
            RuleFor(m => m.City).NotEmpty().Length(1, 30);
            RuleFor(m => m.CountyCode).NotEmpty().Length(1, 2);
            RuleFor(m => m.Street).NotEmpty().Length(1, 100);
            RuleFor(m => m.Building).MaximumLength(30);
            RuleFor(m => m.Stair).MaximumLength(5);
            RuleFor(m => m.Floor).MaximumLength(5);
            RuleFor(m => m.FlatNo).MaximumLength(5);

            RuleFor(m => m.CountyCode).MustAsync(checks.CountyExists).WithMessage("Codul judetului este invalid");
        }
    }

}
