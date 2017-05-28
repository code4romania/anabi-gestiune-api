using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class PersoanaDb
    {
        public int Id { get; set; }

        public int AdresaId { get; set; }
        
        public virtual AdresaDb Adresa { get; set; }

        public string Denumire { get; set; }

        public string Identificator { get; set; }

        public string SerieCi { get; set; }

        public string NumarCi { get; set; }

        public bool EstePf { get; set; }

        public string CodUtilizatorAdaugare { get; set; }

        public string CodUtilizatorUltimaModificare { get; set; }

        public DateTime DataAdaugare { get; set; }

        public DateTime DataUltimeiModificari { get; set; }
                
        public virtual ICollection<DosarDb> Dosare { get; set; }

    }
}
