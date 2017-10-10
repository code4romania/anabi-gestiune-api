using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class StageDb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsFinal { get; set; }

        public virtual ICollection<StagesForDecisionDb> PossibleDecisions { get; set; }

        public virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }

        
    }
}
