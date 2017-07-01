using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class StagesForDecisionDb
    {
        public int Id { get; set; }

        public int StageId { get; set; }

        public virtual StageDb Stage { get; set; }

        public int DecisionId { get; set; }

        public virtual DecisionDb Decision { get; set; }
    }
}
