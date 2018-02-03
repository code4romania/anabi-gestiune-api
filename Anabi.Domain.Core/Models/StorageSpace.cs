namespace Anabi.Domain.Models
{
    public class StorageSpace
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public string Name { get; set; }

        public decimal? TotalVolume { get; set; }

        public decimal? AvailableVolume { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public decimal? AsphaltedArea { get; set; }

        public decimal? UndevelopedArea { get; set; }

        public string ContactData { get; set; }

        public decimal? MonthlyMaintenanceCost { get; set; }

        public string MaintenanceMentions { get; set; }
    }
}
