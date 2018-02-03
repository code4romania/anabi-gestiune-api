using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Assets.Models
{
    public class StorageSpace
    {
        public int Id { get; set; }

        public int AssetId { get; set; }

        public int StorageSpaceId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExitDate { get; set; }

        public string UserCodeAdd { get; set; }

        public string UserCodeLastChange { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastChangeDate { get; set; }
    }
}
