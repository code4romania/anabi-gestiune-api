using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class EtapaIstoricaDb
    {
        public int Id { get; set; }

        public int BunId { get; set; }

        public int EtapaId { get; set; }

        public int DecizieId { get; set; }

        public int InstitutieId { get; set; }

        public virtual BunDb Bun { get; set; }

        public decimal ValoareEstimata { get; set; }

        public string ValutaEstimare { get; set; }

        public virtual EtapaDb Etapa { get; set; }

        public virtual DecizieDb Decizia { get; set; }

        public string CodUtilizatorAdaugare { get; set; }

        public string CodUtilizatorUltimaModificare { get; set; }

        public DateTime DataAdaugare { get; set; }

        public DateTime DataUltimeiModificari { get; set; }

        public string TemeiJuridic { get; set; }

        public string NumarDecizie { get; set; }

        public DateTime DataDeciziei { get; set; }

        public virtual InstitutieDb InstitutiaEmitenta { get; set; }

        public UtilizatorDb UtilizatorAdaugare { get; set; }
        public UtilizatorDb UtilizatorUltimaModificare { get; set; }

    }
}
