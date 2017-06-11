using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class BunDb
    {
        public int Id { get; set; }

        public int AdresaId { get; set; }
        
        public virtual AdresaDb Adresa { get; set; }

        public int CategorieId { get; set; }

        public virtual CategorieDb Categorie { get; set; }

        public int EtapaCurentaId { get; set; }

        public virtual EtapaDb EtapaCurenta { get; set; }

        public int DecizieId { get; set; }

        public virtual DecizieDb DeciziaCurenta { get; set; }


        public virtual ICollection<EtapaIstoricaDb> IstoricEtape { get; set; }

        public bool EsteSters { get; set; }

        

        public string CodUtilizatorAdaugare { get; set; }

        public string CodUtilizatorUltimaModificare { get; set; }

        public DateTime DataAdaugare { get; set; }

        public DateTime DataUltimeiModificari { get; set; }

        public virtual ICollection<BunuriDosarDb> DosareBun { get; set; }
    }
}
