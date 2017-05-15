using System.Collections.Generic;

namespace Anabi.Domain.Core.Models
{
    public class Bun
    {
        public int Id { get; set; }

        public Adresa Adresa { get; set; }


        public int CategorieId { get; set; }

        public Categorie Categorie { get; set; }

        public Etapa EtapaCurenta { get; set; }

        public Decizie DeciziaCurenta { get; set; }

        public List<EtapaIstorica> IstoricEtape { get; set; }

        public bool EsteSters { get; set; }

        public List<Dosar> Dosare { get; set; }

        public DetaliuJurnal DetaliuJurnal { get; set; }

    }
}
