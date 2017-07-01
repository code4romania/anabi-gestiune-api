using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Core.Models
{
    public class HistoricalStage
    {
        public int Id { get; set; }

        public Asset Asset { get; set; }

        public Stage Stage { get; set; }

        public Decision Decision { get; set; }

        public Journal Journal { get; set; }

        public string LegalBasis { get; set; }

        public string DecisionNumber { get; set; }

        public DateTime DecisionDate { get; set; }

        public Institution IssuingInstitution { get; set; }
    }
}
