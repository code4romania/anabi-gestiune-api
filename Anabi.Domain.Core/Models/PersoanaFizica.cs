using System;

namespace Anabi.Domain.Core.Models
{
    public class PersoanaFizica : Persoana
    {
        public string Nume { get; set; }

        public string Prenume { get; set; }

        public string Cnp { get; set; }

        public string SerieCi { get; set; }

        public string NumarCi { get; set; }


        public override string Denumire { get { return Nume + " " + Prenume; } }

        public override string Identificator { get { return Cnp; } }


    }
}
