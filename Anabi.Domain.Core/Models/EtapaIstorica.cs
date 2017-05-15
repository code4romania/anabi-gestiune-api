using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Core.Models
{
    public class EtapaIstorica
    {
        public int Id { get; set; }

        public Bun Bun { get; set; }

        public Etapa Etapa { get; set; }

        public Decizie Decizia { get; set; }

        public DetaliuJurnal DetaliuJurnal { get; set; }

        public string TemeiJuridic { get; set; }

        public string NumarDecizie { get; set; }

        public DateTime DataDeciziei { get; set; }

        public Institutie InstitutiaEmitenta { get; set; }
    }
}
