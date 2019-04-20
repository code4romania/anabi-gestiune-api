using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("RecoveryBeneficiaries")]
    public class RecoveryBeneficiaryDb : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
