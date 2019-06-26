using Anabi.Common.Utils;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.Asset.Commands
{
    public class AddAssetAddressRequest
    {
        public int CountyId { get; set; }

        [MaxLength(100, ErrorMessage = Constants.ADDRESS_STREET_INVALID_NAME)]
        [Required]
        public string Street { get; set; }

        [MaxLength(30, ErrorMessage = Constants.ADDRESS_CITY_INVALID_NAME)]
        [Required]
        public string City { get; set; }

        [MaxLength(10, ErrorMessage = Constants.ADDRESS_BUILDING_INVALID_NUMBER)]
        [Required]
        public string Building { get; set; }

        [MaxLength(5, ErrorMessage = Constants.ADDRESS_STAIR_INVALID_NUMBER)]
        [Required]
        public string Stair { get; set; }

        [MaxLength(5, ErrorMessage = Constants.ADDRESS_FLOOR_INVALID_NUMBER)]
        [Required]
        public string Floor { get; set; }

        [MaxLength(5, ErrorMessage = Constants.ADDRESS_FLATNO_INVALID_NUMBER)]
        [Required]
        public string FlatNo { get; set; }

        [MaxLength(300, ErrorMessage = Constants.ADDRESS_DESCRIPTION_INVALID)]
        [Required]
        public string Description { get; set; }
    }
}