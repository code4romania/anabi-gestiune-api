using System.Collections.Generic;

namespace Anabi.Domain.Core.Models
{
    public abstract class Persoana
    {
        public int Id { get; set; }

        public Adresa Adresa { get; set; }

        abstract public string Denumire { get; }

        abstract public string Identificator { get; }

        public bool EstePf { get; set; }

        public List<Dosar> Dosare { get; set; }

        public DetaliuJurnal DetaliuJurnal { get; set; }
    }
}
