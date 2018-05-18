using Anabi.Common.Enums;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class StageDb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public StageCategory? StageCategory { get; set; }

        public string Description { get; set; }

        public bool IsFinal { get; set; }

        public int? ParentId { get; set; }

        public virtual StageDb Parent { get; set; }

        public ICollection<StageDb> Children { get; set; }

        public virtual ICollection<StagesForDecisionDb> PossibleDecisions { get; set; }

        public virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }

        
    }
}
