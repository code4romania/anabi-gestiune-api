using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class BunSpatiuStocareDb
    {
        public int Id { get; set; }

        public BunDb Bun { get; set; }
        public int BunId { get; set; }

        public SpatiuStocareDb SpatiuStocare { get; set; }
        public int SpatiuStocareId { get; set; }

        public DateTime DataIntrare { get; set; }

        public DateTime? DataIesire { get; set; }

        public UtilizatorDb UtilizatorAdaugare { get; set; }
        public UtilizatorDb UtilizatorUltimaModificare { get; set; }


        public string CodUtilizatorAdaugare { get; set; }

        public string CodUtilizatorUltimaModificare { get; set; }

        public DateTime DataAdaugare { get; set; }

        public DateTime? DataUltimeiModificari { get; set; }
    }
}
