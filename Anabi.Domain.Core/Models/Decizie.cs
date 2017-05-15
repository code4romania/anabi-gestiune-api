using System.Collections.Generic;

namespace Anabi.Domain.Core.Models
{
    public class Decizie
    {
        public int Id { get; set; }

        public List<Etapa> EtapePosibile { get; set; }

        public string Denumire { get; set; }

    }
}
