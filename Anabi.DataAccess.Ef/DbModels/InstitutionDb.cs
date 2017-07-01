using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class InstitutionDb
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDb Category { get; set; }

        public string Name { get; set; }

        public int? AddressId { get; set; }

        public virtual AddressDb Address { get; set; }

        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public virtual ICollection<FileNumberDb> FileNumbers { get; set; }

        public virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }


        public UserDb UserAdd { get; set; }
        public UserDb UserLastChange { get; set; }
    }
}
