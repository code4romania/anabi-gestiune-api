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
    }
}
