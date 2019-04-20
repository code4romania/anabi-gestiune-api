using Anabi.DataAccess.Ef.DbModels;
public class AddAssetAddressRequest
    {
        public int CountyId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Building { get; set;}

        public string Description{ get; set; }
    }