using Anabi.Common.ViewModels;

namespace Anabi.DataAccess.Ef.DbModels.Extensions
{
    public static class AddressDbExtensions
    {
        public static StorageSpaceAddressViewModel ToStorageSpaceAddressViewModel(this AddressDb addressDb)
        {
            return new StorageSpaceAddressViewModel
            {
                Id = addressDb.Id,
                County = new CountyViewModel
                {
                    Id = addressDb.CountyId,
                    Name = addressDb.County?.Name,
                    Abreviation = addressDb.County?.Abreviation
                },
                City = addressDb.City,
                Street = addressDb.Street,
                Building = addressDb.Building
            };
        }

        public static AddressViewModel ToAddressViewModel(this AddressDb addressDb)
        {
            return new AddressViewModel
            {
                Id = addressDb.Id,
                CountyAbreviation = addressDb.County?.Abreviation,
                CountyId = addressDb.CountyId,
                CountyName = addressDb.County?.Name,

                City = addressDb.City,
                Street = addressDb.Street,
                Building = addressDb.Building,
                Journal = addressDb.GetJournalViewModel(),
            };
        }

    }
}
