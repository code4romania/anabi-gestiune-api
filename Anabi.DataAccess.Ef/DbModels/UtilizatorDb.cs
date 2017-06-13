using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class UtilizatorDb
    {
        public int Id { get; set; }

        public string CodUtilizator { get; set; }

        public string Parola { get; set; }

        public string Salt { get; set; }

        public string Email { get; set; }

        public string Nume { get; set; }

        public string Rol { get; set; }

        public bool EsteActiv { get; set; }

        public virtual ICollection<NumarDosarDb> NumareDosareAdaugare { get; set; }
        public virtual ICollection<NumarDosarDb> NumareDosareModificare { get; set; }

        public virtual ICollection<BunDb> BunuriAdaugare { get; set; }
        public virtual ICollection<BunDb> BunuriModificare { get; set; }

        public virtual ICollection<BunuriDosarDb> BunuriDosarAdaugare { get; set; }
        public virtual ICollection<BunuriDosarDb> BunuriDosarModificare { get; set; }

        public virtual ICollection<DosarDb> DosareAdaugare { get; set; }
        public virtual ICollection<DosarDb> DosareModificare
        {
            get; set;
        }

        public virtual ICollection<EtapaIstoricaDb> EtapeIstoriceAdaugare { get; set; }
        public virtual ICollection<EtapaIstoricaDb> EtapeIstoriceModificare { get; set; }

        public virtual ICollection<InculpatiDosarDb> InculpatiDosareAdaugare { get; set; }
        public virtual ICollection<InculpatiDosarDb> InculpatiDosareModificare { get; set; }

        public virtual ICollection<InstitutieDb> InstitutiiAdaugare { get; set; }
        public virtual ICollection<InstitutieDb> InstitutiiModificare { get; set; }

        public virtual ICollection<PersoanaDb> PersoaneAdaugare { get; set; }
        public virtual ICollection<PersoanaDb> PersoaneModificare { get; set; }

        public virtual ICollection<BunSpatiuStocareDb> BunuriSpatiiStocareAdaugare { get; set; }
        public virtual ICollection<BunSpatiuStocareDb> BunuriSpatiiStocareModificare { get; set; }
    }
}
