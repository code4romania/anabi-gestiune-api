using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class PersonDb : BaseEntity
    {

        public int? AddressId { get; set; }
        
        public virtual AddressDb Address { get; set; }

        public string Name { get; set; }

        public string Identification { get; set; }

        public string IdSerie { get; set; }

        public string IdNumber { get; set; }

        public bool IsPerson { get; set; }

                
        public virtual ICollection<DefendantsFileDb> Files { get; set; }

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

    }
}
