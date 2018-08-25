using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class AssetsFileDb : BaseEntity
    {
        public int AssetId { get; set; }

        public virtual AssetDb Asset { get; set; }

        public int FileId { get; set; }

        public virtual FileDb File { get; set; }
       
    }
}
