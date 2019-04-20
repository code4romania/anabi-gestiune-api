using Anabi.Common.Enums;
using Anabi.Common.Utils;
using Anabi.Domain.Common;
using Anabi.Domain.Common.Address;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.StorageSpaces.Commands
{
    public class AddStorageSpace : IRequest<int>, IAddMinimalAddress
    {         
        public string Name { get; set; }

        [EnumDataType(typeof(StorageSpaceTypeEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public StorageSpaceTypeEnum StorageSpaceType { get; set; }
       
        public string CountyCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Details { get; set; }
    }

    public class AddStorageSpaceValidator : AbstractValidator<AddStorageSpace>
    {
        public AddStorageSpaceValidator(IDatabaseChecks checks, AbstractValidator<IAddMinimalAddress>  addAddressValidator)
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(Constants.NAME_NOT_EMPTY);
            RuleFor(c => c.Name).MaximumLength(200).WithMessage(Constants.NAME_MAX_LENGTH_100);

            RuleFor(c => c.StorageSpaceType).NotEmpty().WithMessage(Constants.STORAGE_SPACE_TYPE_NOT_EMPTY);
            RuleFor(c => c.Details).MaximumLength(300).WithMessage(Constants.DESCRIPTION_MAX_LENGTH_2000);

            RuleFor(m => m).SetValidator(addAddressValidator); 
        }
    }
}
