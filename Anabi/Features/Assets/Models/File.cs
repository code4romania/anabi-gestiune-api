using System;
using System.Collections.Generic;

namespace Anabi.Features.Assets.Models
{
    public class File
    {
        public int Id { get; set; }

        public List<Defendant> Defendants { get; set; }

        public int InitialFileId { get; set; }
        public string InitialFileNumber { get; set; }

        public int CurrentFileNumberId { get; set; }
        public string CurrentFileNumber { get; set; }


        public decimal DamageAmount { get; set; }

        public string DamageCurrency { get; set; }

        /// <summary>
        /// Incadrare juridica
        /// </summary>
        public string LegalClassification { get; set; }

        /// <summary>
        /// Domeniu infractional
        /// </summary>
        public string CriminalField { get; set; }


        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }
    }
}
