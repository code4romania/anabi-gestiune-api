
using Anabi.Domain.Models;

namespace Anabi.Features.Institution
{
    public class Institution
    {
        public int Id { get; set; }

        public Category.Models.Category Category { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public Journal Journal { get; set; }
    }
}
