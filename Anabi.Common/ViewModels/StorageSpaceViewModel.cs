using Anabi.Common.Enums;

namespace Anabi.Common.ViewModels
{
    public class StorageSpaceViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public StorageSpaceTypeEnum StorageSpaceType { get; set; }

        public StorageSpaceAddressViewModel Address { get; set; }
    }
}
