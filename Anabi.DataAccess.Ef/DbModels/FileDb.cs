using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class FileDb
    {
        public int Id { get; set; }

        public int InitialFileId { get; set; }

        public virtual FileNumberDb InitialNumber { get; set; }

        public string InitialFileNumber { get; set; }
        

        public int CurrentFileNumberId { get; set; }

        public virtual FileNumberDb CurrentNumber { get; set; }

        public string CurrentFileNumber { get; set; }


        public virtual ICollection<FileNumberDb> Numbers { get; set; }

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


        public virtual ICollection<DefendantsFileDb> Defendants { get; set; }

        public virtual ICollection<AssetDb> Assets { get; set; }
        public virtual ICollection<AssetsFileDb> AssetsFile { get; set; }

        public UserDb UserAdd { get; set; }
        public UserDb UserLastChange { get; set; }
    }
}
