using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class BunuriDosarDb
    {
        public int Id { get; set; }

        public int BunId { get; set; }

        public virtual BunDb Bun { get; set; }

        public int DosarId { get; set; }

        public virtual DosarDb Dosar { get; set; }

        public string CodUtilizatorAdaugare { get; set; }

        public string CodUtilizatorUltimaModificare { get; set; }

        public DateTime DataAdaugare { get; set; }

        public DateTime DataUltimeiModificari { get; set; }
    }
}
