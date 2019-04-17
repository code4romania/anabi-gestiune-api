using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    /// <summary>
    /// Inculpati
    /// </summary>
    /// 
    [Table("AssetDefendants")]
    public class AssetDefendantDb : BaseEntity
    {
        public int AssetId { get; set; }

        public int PersonId { get; set; }

        public virtual AssetDb Asset { get; set; }

        public virtual PersonDb Defendant { get; set; }

    }
}
