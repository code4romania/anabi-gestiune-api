using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    /// <summary>
    /// Proprietari
    /// </summary>
    /// 
    [Table("AssetOwners")]
    public class AssetOwnerDb : BaseEntity
    {
        public int AssetId { get; set; }

        public int PersonId { get; set; }

        public virtual AssetDb Asset { get; set; }

        public virtual PersonDb Owner { get; set; }

    }
}