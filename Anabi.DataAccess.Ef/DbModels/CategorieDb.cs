using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class CategorieDb
    {
        public int Id { get; set; }

        public int? ParinteId { get; set; }

        public string Cod { get; set; }

        public string Descriere { get; set; }

        public virtual CategorieDb Parinte { get; set; }

        /// <summary>
        /// Ex: Decizie, Bun, Institutie
        /// </summary>
        public string PentruEntitate { get; set; }

        public ICollection<CategorieDb> Copii { get; set; }

        public virtual ICollection<InstitutieDb> Institutii { get; set; }
    }
}
