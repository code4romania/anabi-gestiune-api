using Anabi.Common.Enums;
using Anabi.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.StorageSpaces.Models
{
    public class StorageSpaceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [EnumDataType(typeof(StorageSpaceTypeEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public StorageSpaceTypeEnum StorageSpaceType { get; set; }

        public Address Addresss { get; set; }
    }
}
