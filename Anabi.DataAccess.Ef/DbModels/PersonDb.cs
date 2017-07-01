using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class PersonDb
    {
        public int Id { get; set; }

        public int AddressId { get; set; }
        
        public virtual AddressDb Address { get; set; }

        public string Name { get; set; }

        public string Identification { get; set; }

        public string IdSerie { get; set; }

        public string IdNumber { get; set; }

        public bool IsPerson { get; set; }

        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }
                
        public virtual ICollection<DefendantsFileDb> Files { get; set; }

        public UserDb UserAdd { get; set; }
        public UserDb UserLastChange { get; set; }

    }
}
