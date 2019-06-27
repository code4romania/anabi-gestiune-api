using Anabi.Common.Enums;
using Anabi.Common.ViewModels;
using Anabi.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Features.StorageSpaces.Models
{
    public class StorageSpaceViewModel : BaseViewModel
    {
        public string Name { get; set; }

        [EnumDataType(typeof(StorageSpaceTypeEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public StorageSpaceTypeEnum StorageSpaceType { get; set; }

        public Address Addresss { get; set; }
    }
}
