﻿namespace Anabi.Common.ViewModels
{
    public class StorageSpaceAddressViewModel : BasicViewModel
    {
        public CountyViewModel County { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Building { get; set; }

        public string Description { get; set; }
    }
}
