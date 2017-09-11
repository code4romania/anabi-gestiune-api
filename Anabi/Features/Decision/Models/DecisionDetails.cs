using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Features.Decision.Models
{
    public class DecisionDetails
    {
        public int Id { get; set; }

        public int AssetId { get; set; }
        public string AssetUniqueIdentifier { get; set; }

        public int StageId { get; set; }
        public string StageName { get; set; }

        public int DecizieId { get; set; }
        public string DecisionName { get; set; }

        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }

        public decimal EstimatedAmount { get; set; }

        public string EstimatedAmountCurrency { get; set; }

        
        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public string AssetState { get; set; }

        public int? OwnerId { get; set; }

        public string OwnerName { get; set; }

        public decimal? ActualValue { get; set; }

        public string ActualValueCurrency { get; set; }

        /// <summary>
        /// Temei juridic
        /// </summary>
        public string LegalBasis { get; set; }

        public string DecisionNumber { get; set; }

        public DateTime DecisionDate { get; set; }

        


    }
}
