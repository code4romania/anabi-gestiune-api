using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("Identifiers")]
    public class IdentifierDb
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string IdentifierType { get; set; }

        public bool IsForPerson { get; set; }

        [StringLength(20)]
        [Required]
        public string UserCodeAdd { get; set; }

        [StringLength(20)]
        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public UserDb UserAdd { get; set; }
        public UserDb UserLastChange { get; set; }


        public virtual ICollection<PersonDb> Persons { get; set; }
    }
}
