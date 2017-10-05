using System;

namespace Anabi.Features.Assets.Models
{
    public class Defendant
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public string Name { get; set; }

        public string Identification { get; set; }

        public string IdSerie { get; set; }

        public string IdNumber { get; set; }

        public bool IsPerson { get; set; }

        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public int FileId { get; set; }
    }
}
