using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Anabi.Common.Enums;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("StorageSpaces")]
    public class StorageSpaceDb : BaseEntity
    {
        public int AddressId { get; set; }

        public virtual AddressDb Address { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public StorageSpaceTypeEnum StorageSpacesType { get; set; }

        public virtual ICollection<AssetStorageSpaceDb> AssetsStorageSpaces { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }
    }
}
