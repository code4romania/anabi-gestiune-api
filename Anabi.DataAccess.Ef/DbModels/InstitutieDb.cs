using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class InstitutieDb
    {
        public int Id { get; set; }

        public int CategorieId { get; set; }

        public virtual CategorieDb Categorie { get; set; }

        public string Denumire { get; set; }

        public int? AdresaId { get; set; }

        public virtual AdresaDb Adresa { get; set; }

        public string CodUtilizatorAdaugare { get; set; }

        public string CodUtilizatorUltimaModificare { get; set; }

        public DateTime DataAdaugare { get; set; }

        public DateTime? DataUltimeiModificari { get; set; }

    }
}
