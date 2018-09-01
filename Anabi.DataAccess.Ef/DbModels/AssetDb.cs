using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class AssetDb : BaseEntity
    {
        public string Name { get; set; }

        public int? AddressId { get; set; }
        
        public virtual AddressDb Address { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDb Category { get; set; }

        public string Description { get; set; }

        public int? DecisionId { get; set; }

        public virtual DecisionDb CurrentDecision { get; set; }

        public string Identifier { get; set; }

        public decimal? NecessaryVolume { get; set; }

        public  List<HistoricalStageDb> HistoricalStages { get; set; } =
            new List<HistoricalStageDb>();

        public bool IsDeleted { get; set; }


        public int? NrOfObjects     { get; set; }

        public string MeasureUnit   { get; set; }

        public string Remarks       { get; set; }

        public virtual ICollection<AssetsFileDb> FilesForAsset { get; set; }

        public virtual ICollection<AssetStorageSpaceDb> AssetsStorageSpaces { get; set; }

        public virtual ICollection<AssetDefendantDb> Defendants { get; set; }
    }
}
