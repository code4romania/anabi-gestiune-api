using System;

namespace Anabi.Domain.Core.Models
{
    public class Company : Person
    {
        public string CompanyName { get; set; }

        public string UniqueId { get; set; }


        public override string Name { get { return CompanyName; } }

        public override string Identifier { get { return UniqueId; } }
    }
}
