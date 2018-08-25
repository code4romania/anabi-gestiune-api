using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("Identifiers")]
    public class IdentifierDb : BaseEntity
    {

        [StringLength(50)]
        [Required]
        public string IdentifierType { get; set; }

        public bool IsForPerson { get; set; }


        public virtual ICollection<PersonDb> Persons { get; set; }
    }
}
