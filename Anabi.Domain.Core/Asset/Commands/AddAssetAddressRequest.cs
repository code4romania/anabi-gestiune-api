using Anabi.DataAccess.Ef.DbModels;
public class AddAssetAddressRequest : BaseEntity
    {
         public int CountyId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Building { get; set;}

        public string Stair { get;  set; }

        public string Floor { get; set; }

        public string FlatNo{ get; set; }

        public int AssetId{ get; set; }
    }