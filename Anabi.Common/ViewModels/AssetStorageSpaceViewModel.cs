using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Common.ViewModels
{
    public class AssetStorageSpaceViewModel : BaseViewModel
    {
        public int StorageSpaceId { get; set; }

        public DateTime EntryDate { get; set; }

        public int AssetId {get; set; }
    }
}
