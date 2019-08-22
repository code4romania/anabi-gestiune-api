﻿using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using Anabi.Domain.Common;
using Anabi.Domain.Common.Address;
using Anabi.Validators.Extensions;
using FluentValidation;
using MediatR;

namespace Anabi.Domain.StorageSpaces.Commands
{
    public class EditStorageSpace : IAddAddress, IRequest<StorageSpaceViewModel>, IAddMinimalAddress
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? TotalVolume { get; set; }
        public decimal? AvailableVolume { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal? AsphaltedArea { get; set; }
        public decimal? UndevelopedArea { get; set; }
        public string ContactData { get; set; }
        public decimal? MonthlyMaintenanceCost { get; set; }
        public string MaintenanceMentions { get; set; }

        public string CountyCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Stair { get; set; }
        public string Floor { get; set; }
        public string FlatNo { get; set; }
        public string Details { get; set; }
    }

    public class EditStorageSpaceValidator : AbstractValidator<EditStorageSpace>
    {
        public EditStorageSpaceValidator(IDatabaseChecks checks, 
            AbstractValidator<IAddAddress> addAddressValidator,
            AnabiContext context)
        {
            RuleFor(c => c.Id).MustBeInDbSet(context.Assets).WithMessage(Constants.INVALID_ID);

            RuleFor(c => c.Name).NotEmpty().WithMessage(Constants.NAME_NOT_EMPTY);
            RuleFor(c => c.Name).MaximumLength(200).WithMessage(Constants.NAME_MAX_LENGTH_100);            
            RuleFor(c => c.ContactData).MaximumLength(1000).WithMessage(Constants.CONTACTDATA_MAX_LENGTH_1000);
            RuleFor(c => c.Description).MaximumLength(2000).WithMessage(Constants.DESCRIPTION_MAX_LENGTH_2000);

            RuleFor(m => m).SetValidator(addAddressValidator);
        }
    }
}
