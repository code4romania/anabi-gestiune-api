using Anabi.Common.Utils;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.Asset.Commands
{
    public class AddAssetAddressRequest
    {

        public AddAssetAddressRequest(int countyId, string street, string city, string building, string description)
        {
            CountyId = countyId;
            Street = street;
            City = city;
            Building = building;
            Description = description;
        }

        public int CountyId { get; }

        [Required]
        [MaxLength(100, ErrorMessage = Constants.ADDRESS_STREET_INVALID_NAME)]
        public string Street { get; }

        [Required]
        [MaxLength(30, ErrorMessage = Constants.ADDRESS_CITY_INVALID_NAME)]
        public string City { get; }

        [Required]
        [MaxLength(10, ErrorMessage = Constants.ADDRESS_BUILDING_INVALID_NUMBER)]
        public string Building { get; }

        [Required]
        [MaxLength(300, ErrorMessage = Constants.ADDRESS_DESCRIPTION_INVALID)]
        public string Description { get; }
    }
}