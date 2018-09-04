using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class FileDb : BaseEntity
    {

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




        public virtual ICollection<DefendantsFileDb> Defendants { get; set; }

        public virtual ICollection<AssetDb> Assets { get; set; }
        public virtual ICollection<AssetsFileDb> AssetsFile { get; set; }

    }
}
