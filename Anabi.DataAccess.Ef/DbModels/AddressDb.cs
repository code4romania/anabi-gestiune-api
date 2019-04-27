using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("Addresses")]
    public class AddressDb : BaseEntity
    {
        public int CountyId { get; set; }

        public virtual CountyDb County { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(10)]
        public string Building { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        //pt foreign key

        public virtual ICollection<PersonDb> Persons { get; set; }

        public virtual ICollection<AssetDb> Assets { get; set; }

        public virtual StorageSpaceDb StorageRoom { get; set; }
    }
}
