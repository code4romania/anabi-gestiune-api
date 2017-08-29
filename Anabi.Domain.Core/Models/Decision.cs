using System.Collections.Generic;

namespace Anabi.Domain.Models
{
    public class Decision
    {
        public int Id { get; set; }

        public List<Stage> PossibleStages { get; set; }

        public string Name { get; set; }

    }
}
