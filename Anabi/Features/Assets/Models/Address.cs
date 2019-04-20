namespace Anabi.Features.Assets.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int CountyId { get; set; }

        public string CountyName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Building { get; set; }

        public string Description { get; set; }
    }
}
