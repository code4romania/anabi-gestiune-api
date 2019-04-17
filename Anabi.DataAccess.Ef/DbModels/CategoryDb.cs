using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("Categories")]
    public class CategoryDb : BaseEntity
    {
        public int? ParentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public virtual CategoryDb Parent { get; set; }

        /// <summary>
        /// Ex: Decizie, Bun, Institutie
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string ForEntity { get; set; }

        public ICollection<CategoryDb> Children { get; set; }

        public virtual ICollection<InstitutionDb> Institutions { get; set; }

        public virtual ICollection<AssetDb> Assets { get; set; }
    }
}
