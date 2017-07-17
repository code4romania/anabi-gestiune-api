using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class HistoricalStageDb
    {
        public int Id { get; set; }

        public int AssetId { get; set; }

        public int StageId { get; set; }

        public int DecizieId { get; set; }

        public int InstitutionId { get; set; }

        public virtual AssetDb Asset { get; set; }

        public decimal EstimatedAmount { get; set; }

        public string EstimatedAmountCurrency { get; set; }

        public virtual StageDb Stage { get; set; }

        public virtual DecisionDb Decision { get; set; }

        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public string StareBun { get; set; }

        public int? DetinatorBun { get; set; }

        public decimal? ValoareEfectiva { get; set; }

        public string ValutaValoareEfectiva { get; set; }

        /// <summary>
        /// Temei juridic
        /// </summary>
        public string LegalBasis { get; set; }

        public string DecisionNumber { get; set; }

        public DateTime DecisionDate { get; set; }

        public virtual InstitutionDb IssuingInstitution { get; set; }

        public UserDb UserAdd { get; set; }
        public UserDb UserLastChange { get; set; }

    }
}
