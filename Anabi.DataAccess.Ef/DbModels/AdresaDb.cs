using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class AdresaDb
    {
        public int Id { get; set; }

        public int JudetId { get; set; }

        public virtual JudetDb Judet { get; set; }

        public string Strada { get; set; }

        public string Oras { get; set; }

        public string Cladire { get; set; }

        public string Scara { get; set; }

        public string Etaj { get; set; }

        public string NrApartament { get; set; }

        //pt foreign key

        public virtual ICollection<InstitutieDb> Institutii { get; set; }

        public virtual ICollection<PersoanaDb> Persoane { get; set; }

        public virtual ICollection<BunDb> Bunuri { get; set; }

        public virtual SpatiuStocareDb SpatiuStocare { get; set; }
    }
}
