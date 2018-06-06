using System;

namespace Anabi.Common.ViewModels
{
    public class JournalViewModel
    {
        public DateTime AddedDate { get; set; }

        public string UserCodeAdd { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public string UserCodeLastChange { get; set; }
    }
}
