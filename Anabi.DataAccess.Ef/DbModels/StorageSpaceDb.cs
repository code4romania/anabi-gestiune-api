using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class StorageSpaceDb
    {
        public int Id { get; set; }

        public int AddressId { get; set; }

        public virtual AddressDb Address { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AssetStorageSpaceDb> AssetsStorageSpaces { get; set; }

        public decimal? TotalVolume { get; set; }

        public decimal? AvailableVolume { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDb Category { get; set; }

        public decimal? AsphaltedArea { get; set; }

        public decimal? UndevelopedArea { get; set; }

        public string ContactData { get; set; }

        public decimal? MonthlyMaintenanceCost { get; set; }

        public string MaintenanceMentions { get; set; }
    }
}
