using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class FileNumberDb
    {
        public int Id { get; set; }

                
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

        public UserDb UserAdd { get; set; }

        public string UserCodeAdd { get; set; }

        public UserDb UserLastChange { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        

    }
}
