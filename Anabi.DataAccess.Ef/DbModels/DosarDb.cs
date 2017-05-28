using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class DosarDb
    {
        public int Id { get; set; }

        public int NumarDosarInitialId { get; set; }

        public virtual NumarDosarDb NumarInitial { get; set; }

        public string NumarDosarInitial { get; set; }


        public int NumarDosarCurentId { get; set; }

        public virtual NumarDosarDb NumarCurent { get; set; }

        public string NumarDosarCurent { get; set; }


        public virtual ICollection<NumarDosarDb> Numere { get; set; }

        public decimal Prejudiciu { get; set; }

        public string ValutaPrejudiciu { get; set; }

        public string IncadrareJuridica { get; set; }

        public string DomeniuInfractional { get; set; }


   

        public string CodUtilizatorAdaugare { get; set; }

        public string CodUtilizatorUltimaModificare { get; set; }

        public DateTime DataAdaugare { get; set; }

        public DateTime DataUltimeiModificari { get; set; }


        public virtual ICollection<PersoanaDb> Inculpati { get; set; }

        public virtual ICollection<BunDb> Bunuri { get; set; }
    }
}
