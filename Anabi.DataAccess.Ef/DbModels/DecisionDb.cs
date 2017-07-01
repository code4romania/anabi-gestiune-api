using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class DecisionDb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<StagesForDecisionDb> PossibleStages { get; set; }

        public virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }

        public virtual ICollection<AssetDb> Assets { get; set; }

    }
}
