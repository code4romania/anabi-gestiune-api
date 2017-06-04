using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class EtapaDb
    {
        public int Id { get; set; }

        public string Denumire { get; set; }

        public bool EsteFinala { get; set; }

        public virtual ICollection<EtapePentruDecizieDb> DeciziiPosibile { get; set; }


    }
}
