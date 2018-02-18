using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    /// <summary>
    /// Inculpati
    /// </summary>
    /// 
    [Table("AssetDefendants")]
    public class AssetDefendantDb
    {
        public int Id { get; set; }

        public int AssetId { get; set; }

        public int PersonId { get; set; }

        public virtual AssetDb Asset { get; set; }

        public virtual PersonDb Person { get; set; }

        [StringLength(20)]
        [Required]
        public string UserCodeAdd { get; set; }

        [StringLength(20)]
        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public UserDb UserAdd { get; set; }
        public UserDb UserLastChange { get; set; }

    }
}
