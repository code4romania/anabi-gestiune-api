
namespace Anabi.Domain.Core.Models
{
    public class Institution
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public Journal Journal { get; set; }
    }
}
