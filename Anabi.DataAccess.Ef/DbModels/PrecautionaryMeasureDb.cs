using Anabi.Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("PrecautionaryMeasures")]
    public class PrecautionaryMeasureDb : BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public PrecautionaryMeasureType Code { get; set; }

        public virtual ICollection<HistoricalStageDb> Stages { get; set; }
    }
}
