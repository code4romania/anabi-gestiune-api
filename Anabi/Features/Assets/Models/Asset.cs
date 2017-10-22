using System;
using System.Collections.Generic;

namespace Anabi.Features.Assets.Models
{
    public class Asset
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Identifier { get; set; }

        public decimal? NecessaryVolume { get; set; }

        public bool IsDeleted { get; set; }

        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public List<StorageSpace> StorageSpaces { get; set; }
    }
}
