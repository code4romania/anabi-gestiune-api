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
    public class AssetDefendantDb : BaseEntity
    {
        public int AssetId { get; set; }

        public int PersonId { get; set; }

        public virtual AssetDb Asset { get; set; }

        public virtual PersonDb Person { get; set; }

    }
}
