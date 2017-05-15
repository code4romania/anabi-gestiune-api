using System;

namespace Anabi.Domain.Core.Models
{
    public class PersoanaJuridica : Persoana
    {
        public string Nume { get; set; }

        public string Cui { get; set; }


        public override string Denumire { get { return Nume; } }

        public override string Identificator { get { return Cui; } }
    }
}
