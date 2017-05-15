
namespace Anabi.Domain.Core.Models
{
    public class Institutie
    {
        public int Id { get; set; }

        public Categorie Categorie { get; set; }

        public string Denumire { get; set; }

        public Adresa Adresa { get; set; }

        public DetaliuJurnal DetaliuJurnal { get; set; }
    }
}
