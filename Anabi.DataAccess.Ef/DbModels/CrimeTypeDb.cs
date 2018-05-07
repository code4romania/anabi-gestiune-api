using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("CrimeTypes")]
    public class CrimeTypeDb : BaseEntity
    {
        [Required]
        [MaxLength(400)]
        public string CrimeName { get; set; }
    }
}
