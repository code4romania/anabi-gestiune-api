
using System;
using System.Collections.Generic;

namespace Anabi.Domain.Core.Models
{
    public class Dosar
    {
        public int Id { get; set; }

       
        public NumarDosar NumarInitial { get; set; }
        public string NumarDosarInitial { get; set; }


        public NumarDosar NumarCurent { get; set; }
        public string NumarDosarCurent { get; set; }

        public List<NumarDosar> Numere { get; set; }      

        public decimal Prejudiciu { get; set; }

        public string ValutaPrejudiciu { get; set; }

        public string IncadrareJuridica { get; set; }

        public string DomeniuInfractional { get; set; }

        public List<Persoana> Inculpati { get; set; }

        public List<Bun> Bunuri { get; set; }

        public DetaliuJurnal DetaliuJurnal { get; set; }
    }
}
