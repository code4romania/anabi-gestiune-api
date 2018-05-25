using System;

namespace Anabi.Domain.Models
{
    public class Journal
    {
        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

    }
}
