namespace Anabi.Domain.Core.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Cod { get; set; }

        public string Descriere { get; set; }

        public int? ParinteId { get; set; }

        public Categorie Parinte { get; set; }

        /// <summary>
        /// Ex: Decizie, Bun, Institutie
        /// </summary>
        public string PentruEntitate { get; set; }

    }
}
