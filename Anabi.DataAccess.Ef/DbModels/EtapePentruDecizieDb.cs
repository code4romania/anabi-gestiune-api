using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class EtapePentruDecizieDb
    {
        public int Id { get; set; }

        public int EtapaId { get; set; }

        public virtual EtapaDb Etapa { get; set; }

        public int DecizieId { get; set; }

        public virtual DecizieDb Decizie { get; set; }
    }
}
