using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class InstitutionDb : BaseEntity
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string ContactData { get; set; }

        
        public virtual ICollection<FileNumberDb> FileNumbers { get; set; }

        public virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }

    }
}
