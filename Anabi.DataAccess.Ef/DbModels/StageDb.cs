using Anabi.Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("Stages")]
    public class StageDb : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public StageCategory? StageCategory { get; set; }

        public string Description { get; set; }

        [Required]
        public bool IsFinal { get; set; }

        public int? ParentId { get; set; }

        public virtual StageDb Parent { get; set; }

        public ICollection<StageDb> Children { get; set; }

        public virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }

        
    }
}
