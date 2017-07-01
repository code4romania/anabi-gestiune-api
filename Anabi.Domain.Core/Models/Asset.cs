using System.Collections.Generic;

namespace Anabi.Domain.Core.Models
{
    public class Asset
    {
        public int Id { get; set; }

        public Address Address { get; set; }


        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Stage CurrentStage { get; set; }

        public Decision CurrentDecision { get; set; }

        public List<HistoricalStage> HistoricalStages { get; set; }

        public bool IsDeleted { get; set; }

        public List<File> Files { get; set; }

        public Journal Journal { get; set; }

    }
}
