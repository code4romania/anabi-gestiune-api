using System;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.Person.Commands
{
    public class ModifyOwnerRequest
    {
        [MaxLength(6)]
        public string IdNumber { get; set; }

        [MaxLength(2)]
        public string IdSerie { get; set; }

        [MaxLength(20)]
        public string Identification { get; set; }

        public bool IsPerson { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        public int IdentifierId { get; set; }

        [MaxLength(20)]
        public string Nationality { get; set; }
    }
}