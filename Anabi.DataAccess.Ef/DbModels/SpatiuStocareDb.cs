using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class SpatiuStocareDb
    {
        public int Id { get; set; }

        public int AdresaId { get; set; }

        public virtual AdresaDb Adresa { get; set; }

        public string Denumire { get; set; }
    }
}
