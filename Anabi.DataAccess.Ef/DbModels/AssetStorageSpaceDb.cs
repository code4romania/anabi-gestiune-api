using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class AssetStorageSpaceDb : BaseEntity
    {
        public AssetDb Asset { get; set; }
        public int AssetId { get; set; }

        public StorageSpaceDb StorageSpace { get; set; }
        public int StorageSpaceId { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExitDate { get; set; }
        
    }
}
