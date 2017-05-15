using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.DbModels
{
    public class NumarDosarDb
    {
        public int Id { get; set; }

        public int DosarId { get; set; }

        public virtual DosarDb Dosar { get; set; }

        public string NrDosar { get; set; }

        /// <summary>
        /// Instanta care a dat numarul
        /// </summary>
        public virtual InstitutieDb Institutie { get; set; }

        public int InstitutieId { get; set; }

        /// <summary>
        /// Data la care a primit numarul de la instanta
        /// </summary>
        public DateTime DataNumarului { get; set; }

        public string CodUtilizatorAdaugare { get; set; }

        public string CodUtilizatorUltimaModificare { get; set; }

        public DateTime DataAdaugare { get; set; }

        public DateTime DataUltimeiModificari { get; set; }
    }
}
