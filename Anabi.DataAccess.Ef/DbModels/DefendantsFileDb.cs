using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class DefendantsFileDb : BaseEntity
    {

        public int PersonId { get; set; }

        public virtual PersonDb Defendant { get; set; }

        public int FileId { get; set; }

        public virtual FileDb File { get; set; }


    }
}
