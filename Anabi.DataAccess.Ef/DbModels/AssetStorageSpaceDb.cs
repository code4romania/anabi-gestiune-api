using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class AssetStorageSpaceDb
    {
        public int Id { get; set; }

        public AssetDb Asset { get; set; }
        public int AssetId { get; set; }

        public StorageSpaceDb StorageSpace { get; set; }
        public int StorageSpaceId { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExitDate { get; set; }

        public UserDb UserAdd { get; set; }
        public UserDb UserLastChange { get; set; }


        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }
    }
}
