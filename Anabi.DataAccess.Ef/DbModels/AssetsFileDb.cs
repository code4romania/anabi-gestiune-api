using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class AssetsFileDb
    {
        public int Id { get; set; }

        public int AssetId { get; set; }

        public virtual AssetDb Asset { get; set; }

        public int FileId { get; set; }

        public virtual FileDb File { get; set; }

        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public UserDb UserAdd { get; set; }
        public UserDb UserLastChange { get; set; }
    }
}
