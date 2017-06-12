using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class InculpatiDosarDb
    {
        public int Id { get; set; }

        public int PersoanaId { get; set; }

        public virtual PersoanaDb Inculpat { get; set; }

        public int DosarId { get; set; }

        public virtual DosarDb Dosar { get; set; }


        public string CodUtilizatorAdaugare { get; set; }

        public string CodUtilizatorUltimaModificare { get; set; }

        public DateTime DataAdaugare { get; set; }

        public DateTime DataUltimeiModificari { get; set; }

        public UtilizatorDb UtilizatorAdaugare { get; set; }
        public UtilizatorDb UtilizatorUltimaModificare { get; set; }
    }
}
