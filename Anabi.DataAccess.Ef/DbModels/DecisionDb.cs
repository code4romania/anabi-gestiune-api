using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("Decisions")]
    public class DecisionDb : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }

        public virtual ICollection<AssetDb> Assets { get; set; }

    }
}
