using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class AssetDb
    {
        public int Id { get; set; }

        public int AddressId { get; set; }
        
        public virtual AddressDb Address { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDb Category { get; set; }


        
        public int DecisionId { get; set; }

        public virtual DecisionDb CurrentDecision { get; set; }

        public string Identifier { get; set; }

        public decimal? NecessaryVolume { get; set; }

        public virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }

        public bool IsDeleted { get; set; }

        public UserDb UserAdd { get; set; }
        public UserDb UserLastChange { get; set; }


        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public virtual ICollection<AssetsFileDb> FilesForAsset { get; set; }

        public virtual ICollection<AssetStorageSpaceDb> AssetsStorageSpaces { get; set; }
    }
}
