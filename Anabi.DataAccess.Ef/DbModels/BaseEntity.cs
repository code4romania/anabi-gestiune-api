using System;
using System.ComponentModel.DataAnnotations;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "INVALID_USERNAME_LENGTH_2_20", MinimumLength = 2)]
        [Required]
        public string UserCodeAdd { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "INVALID_USERNAME_LENGTH_2_20", MinimumLength = 2)]
        public string UserCodeLastChange { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }
    }
}
