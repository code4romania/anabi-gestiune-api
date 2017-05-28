using Anabi.DataAccess.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Anabi.Domain.Core.Models;
using System.Threading.Tasks;
using System.Linq;
using Anabi.DataAccess.Ef;

namespace Anabi.DataAccess.Repositories
{
    public class InculpatiRepository : BaseRepository, IInculpatiRepository
    {
        public InculpatiRepository(AnabiContext ctx)
        {
            context = ctx;
        }
        public async Task<IEnumerable<Persoana>> GetInculpatiAsync()
        {
            return await getInculpati();
        }

        public async Task<IEnumerable<Persoana>> GetInculpatiFiltratiAsync(string filtru)
        {
            var lst = await getInculpati();
            lst = lst.Where(x => x.Denumire.Contains(filtru)).ToList();

            return lst;
        }

        private async Task<IEnumerable<Persoana>> getInculpati()
        {
            var inculpati = new List<Persoana>()
            {
                new PersoanaFizica()
                {
                    Id = 1, Adresa = new Adresa()
                    {
                      Id = 1, Strada = "Strada zxx", JudetId = 1, Oras = "Bucuresti", Cladire = "Bloc 100", Etaj = "3", NrApartament = "23"
                    },
                    Cnp = "1589643682236",
                    EstePf = true,
                    NumarCi = "123123",
                    SerieCi = "RR",
                    Nume = "Popescu",
                    Prenume = "Gigel",
                    Dosare = new List<Dosar>()
                    {
                       new Dosar(){Id = 1, DomeniuInfractional = "Frauda", NumarDosarCurent = "ZS123", NumarDosarInitial ="AA49942", Prejudiciu = 25480, ValutaPrejudiciu = "EUR" },
                       new Dosar(){Id = 2, DomeniuInfractional = "Frauda", NumarDosarCurent = "GG44366", NumarDosarInitial ="TSD422D", Prejudiciu = 152000, ValutaPrejudiciu = "EUR" }
                    },
                    DetaliuJurnal = new DetaliuJurnal()
                    {
                        CodUtilizatorAdaugare = "ion",
                        CodUtilizatorUltimaModificare ="maria",
                        DataAdaugare = new DateTime(2017,5,23,15,45,33),
                        DataUltimeiModificari = new DateTime(2017,6,26,12,25,32)
                    }
                },
                new PersoanaFizica()
                {
                    Id = 2, Adresa = new Adresa()
                    {
                      Id = 2, Strada = "Strada treff", JudetId = 1, Oras = "Bucuresti", Cladire = "A22", Etaj = "-", NrApartament = "-"
                    },
                    Cnp = "198652357155",
                    EstePf = true,
                    NumarCi = "568974",
                    SerieCi = "TT",
                    Nume = "Ionescu",
                    Prenume = "Dani",
                    Dosare = new List<Dosar>()
                    {
                       new Dosar(){Id = 3, DomeniuInfractional = "Delapidare", NumarDosarCurent = "EE443322", NumarDosarInitial ="RT33232", Prejudiciu = 387952, ValutaPrejudiciu = "EUR" },
                       new Dosar(){Id = 4, DomeniuInfractional = "Delapidare", NumarDosarCurent = "TT1231312", NumarDosarInitial ="ZZAADD#33", Prejudiciu = 452178, ValutaPrejudiciu = "EUR" }
                    },
                    DetaliuJurnal = new DetaliuJurnal()
                    {
                        CodUtilizatorAdaugare = "ion",
                        CodUtilizatorUltimaModificare ="maria",
                        DataAdaugare = new DateTime(2017,2,13,13,35,53),
                        DataUltimeiModificari = new DateTime(2017,5,27,12,25,32)
                    }
                }

            };

            return await Task.FromResult(inculpati);
        }
    }
}
