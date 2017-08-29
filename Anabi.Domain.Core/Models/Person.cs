using System.Collections.Generic;

namespace Anabi.Domain.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        abstract public string Name { get; }

        abstract public string Identifier { get; }

        public bool IsPerson { get; set; }

        public List<File> Files { get; set; }

        public Journal Journal { get; set; }
    }
}
