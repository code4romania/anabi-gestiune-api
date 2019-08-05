using Anabi.Common.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("Assets")]
    public class AssetDb : BaseEntity
    {
        [Required(ErrorMessage = Constants.NAME_NOT_EMPTY)]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = Constants.NAME_MAX_LENGTH_100)]
        public string Name { get; set; }

        public int? AddressId { get; set; }
        
        public virtual AddressDb Address { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDb Category { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public int? DecisionId { get; set; }

        public virtual DecisionDb CurrentDecision { get; set; }

        [MaxLength(100, ErrorMessage = Constants.IDENTIFIER_MAX_LENGTH_100)]
        public string Identifier { get; set; }

        [Column(TypeName = "decimal(20, 2)")]
        public decimal? NecessaryVolume { get; set; }

        public  virtual ICollection<HistoricalStageDb> HistoricalStages { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public int? NrOfObjects     { get; set; }

        [MaxLength(10, ErrorMessage = Constants.MEASUREUNIT_MAX_LENGTH_10)]
        public string MeasureUnit   { get; set; }

        [MaxLength(2000, ErrorMessage = Constants.REMARKS_MAX_LENGTH_2000)]
        public string Remarks       { get; set; }

        public virtual ICollection<AssetStorageSpaceDb> AssetsStorageSpaces { get; set; }

        public virtual ICollection<AssetDefendantDb> Defendants { get; set; }

        public virtual ICollection<AssetOwnerDb> Owners { get; set; }
    }
}
