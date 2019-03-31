
using Anabi.Domain.Models;

namespace Anabi.Features.Institution.Models
{
    public class Institution
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public string ContactData { get; set; }
    }
}
