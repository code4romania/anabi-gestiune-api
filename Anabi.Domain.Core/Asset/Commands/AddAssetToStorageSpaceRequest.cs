using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Asset.Commands
{
    public class AddAssetToStorageSpaceRequest
    {
        public int StorageSpaceId { get; set; }

        public DateTime EntryDate { get; set; }

        public int AssetId { get; set; }
    }
}
