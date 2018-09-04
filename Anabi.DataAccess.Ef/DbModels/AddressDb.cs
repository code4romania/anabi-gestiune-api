using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("Addresses")]

    public class AddressDb : BaseEntity
    {
        public int CountyId { get; set; }

        public virtual CountyDb County { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Building { get; set; }

        public string Stair { get; set; }

        public string Floor { get; set; }

        public string FlatNo { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        //pt foreign key

        public virtual ICollection<InstitutionDb> Institutions { get; set; }

        public virtual ICollection<PersonDb> Persons { get; set; }

        public virtual ICollection<AssetDb> Assets { get; set; }

        public virtual StorageSpaceDb StorageRoom { get; set; }
    }
}
