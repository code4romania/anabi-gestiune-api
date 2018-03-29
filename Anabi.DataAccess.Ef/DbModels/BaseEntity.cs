using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }
    }
}
