using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class CategoryDb
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public virtual CategoryDb Parent { get; set; }

        /// <summary>
        /// Ex: Decizie, Bun, Institutie
        /// </summary>
        public string ForEntity { get; set; }

        public ICollection<CategoryDb> Children { get; set; }

        public virtual ICollection<InstitutionDb> Institutions { get; set; }

        public virtual ICollection<AssetDb> Assets { get; set; }
    }
}
