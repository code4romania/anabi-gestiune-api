using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class UtilizatorDb
    {
        public int Id { get; set; }

        public string CodUtilizator { get; set; }

        public string Email { get; set; }

        public string Nume { get; set; }

        public string Rol { get; set; }
    }
}
