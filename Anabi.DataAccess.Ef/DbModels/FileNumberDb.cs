using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class FileNumberDb : BaseEntity
    {
                
        public string FileNumber { get; set; }

        /// <summary>
        /// Instanta care a dat numarul
        /// </summary>
        public virtual InstitutionDb Institution { get; set; }

        public int InstitutionId { get; set; }

        /// <summary>
        /// Data la care a primit numarul de la instanta
        /// </summary>
        public DateTime NumberDate { get; set; }

    }
}
