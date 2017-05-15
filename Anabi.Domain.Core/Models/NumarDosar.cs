using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Core.Models
{
    public class NumarDosar
    {
        public int Id { get; set; }

        public int DosarId { get; set; }
        
        public string NrDosar { get; set; }

        /// <summary>
        /// Instanta care a dat numarul
        /// </summary>
        public Institutie Instanta { get; set; }

        /// <summary>
        /// Data la care a primit numarul de la instanta
        /// </summary>
        public DateTime DataNumarului { get; set; }

        public DetaliuJurnal DetaliuJurnal { get; set; }
    }
}
