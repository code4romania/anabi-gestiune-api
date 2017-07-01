using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class AddressDb
    {
        public int Id { get; set; }

        public int CountyId { get; set; }

        public virtual CountyDb County { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Building { get; set; }

        public string Stair { get; set; }

        public string Floor { get; set; }

        public string FlatNo { get; set; }

        //pt foreign key

        public virtual ICollection<InstitutionDb> Institutions { get; set; }

        public virtual ICollection<PersonDb> Persons { get; set; }

        public virtual ICollection<AssetDb> Assets { get; set; }

        public virtual StorageSpaceDb StorageRoom { get; set; }
    }
}
