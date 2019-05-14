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
        [MaxLength(200, ErrorMessage = Constants.NAME_NOT_EMPTY)]
        public string Name { get; set; }

        [EnumDataType(typeof(StorageSpaceTypeEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public StorageSpaceTypeEnum StorageSpaceType { get; set; }
       
        [MaxLength(2)]
        public string CountyCode { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(100)]
        public string Street { get; set; }

        [MaxLength(10)]
        public string Building { get; set; }

        [MaxLength(2000, ErrorMessage = Constants.DESCRIPTION_MAX_LENGTH_2000)]
        public string Details { get; set; }
    }

    public class AddStorageSpaceValidator : AbstractValidator<AddStorageSpace>
    {
        public AddStorageSpaceValidator(AbstractValidator<IAddMinimalAddress>  addAddressValidator)
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(Constants.NAME_NOT_EMPTY);

            RuleFor(c => c.StorageSpaceType).NotEmpty().WithMessage(Constants.STORAGE_SPACE_TYPE_NOT_EMPTY);

            RuleFor(m => m).SetValidator(addAddressValidator); 
        }
    }
}
