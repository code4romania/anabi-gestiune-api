using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("AssetStorageSpaces")]
    public class AssetStorageSpaceDb : BaseEntity
    {
        public AssetDb Asset { get; set; }
        public int AssetId { get; set; }

        public StorageSpaceDb StorageSpace { get; set; }
        public int StorageSpaceId { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        public DateTime? ExitDate { get; set; }
        
    }
}
