using System.Collections.Generic;

namespace Anabi.Common.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        public int CountyId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Building { get; set;}

        public string Stair { get;  set; }

        public string Floor { get; set; }

        public string FlatNo { get; set; }
        
        public string Description { get; set; }
    }
}