using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("Persons")]
    public class PersonDb : BaseEntity
    {

        public int? AddressId { get; set; }
        
        public virtual AddressDb Address { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Identification { get; set; }

        [MaxLength(2)]
        public string IdSerie { get; set; }

        [MaxLength(6)]
        public string IdNumber { get; set; }

        [Required]
        public bool IsPerson { get; set; }

                
        public virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }

        public DateTime? Birthdate { get; set; }

        [StringLength(20)]
        public string Nationality { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        public int IdentifierId { get; set; }

        public virtual IdentifierDb Identifier { get; set; }

        public virtual ICollection<AssetDefendantDb> Defendants { get; set; }

        public virtual ICollection<AssetOwnerDb> Owners { get; set; }

    }
}
