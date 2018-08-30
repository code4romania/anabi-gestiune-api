using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string UserCodeAdd { get; set; }

        [StringLength(20)]
        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }
    }
}
