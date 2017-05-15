using Anabi.DataAccess.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Anabi.Domain.Core.Models;
using System.Threading.Tasks;

namespace Anabi.DataAccess.Repositories
{
    public class BunuriRepository : IBunuriRepository
    {
        public async Task<IEnumerable<Bun>> GetBunuriAsync()
        {
            return await getBunuriAsync();
        }

        

        private async Task<IEnumerable<Bun>> getBunuriAsync()
        {
            var lst = new List<Bun>()
            {
                new Bun()
                {
                    Id = 1, Adresa = new Adresa()
                    {
                        Id = 14, Cladire = "Bloc 23S", Strada = "Strada xx", Etaj = "8", JudetId = 2, NrApartament = "23", Oras = "Bucuresti", Scara = "A"
                    },CategorieId = 2, 
                    Categorie = new Categorie(){
                        PentruEntitate = "bunuri", Id = 2, Cod= "Bunuri Imobile", Descriere = "Bunuri imobile", ParinteId = null
                    },
                    DeciziaCurenta = new Decizie()
                    {
                        Denumire = "Hotarare", Id = 1
                    },
                    DetaliuJurnal = new DetaliuJurnal()
                    {
                        CodUtilizatorAdaugare = "ion",
                        CodUtilizatorUltimaModificare ="maria",
                        DataAdaugare = new DateTime(2017,5,23,15,45,33),
                        DataUltimeiModificari = new DateTime(2017,6,26,12,25,32)
                    },
                    Dosare = new List<Dosar>()
                    {
                       new Dosar(){Id = 1, DomeniuInfractional = "Frauda", NumarDosarCurent = "ZS123", NumarDosarInitial ="AA49942", Prejudiciu = 25480, ValutaPrejudiciu = "EUR" },
                       new Dosar(){Id = 2, DomeniuInfractional = "Frauda", NumarDosarCurent = "GG44366", NumarDosarInitial ="TSD422D", Prejudiciu = 152000, ValutaPrejudiciu = "EUR" }
                    },
                    EsteSters = false,
                    EtapaCurenta = new Etapa()
                    {
                        Id = 2, Denumire = "Confiscare"
                    },
                    IstoricEtape = new List<EtapaIstorica>()
                    {
                        new EtapaIstorica()
                        {
                            Id = 1, DataDeciziei = new DateTime(2017,1,2,15,43,23),
                            Decizia = new Decizie()
                                        {
                                            Denumire = "Hotarare", Id = 1
                                        },
                            Etapa = new Etapa()
                                        {
                                            Id = 1, Denumire = "Sechestru"
                                        },
                            InstitutiaEmitenta = new Institutie()
                            {
                                Id = 1, Denumire = "Parchetul cutare", Categorie = new Categorie(){ Id = 12, Cod="Parchet", Descriere = "Parchet"}
                            }
                        },

                        new EtapaIstorica()
                        {
                            Id = 1, DataDeciziei = new DateTime(2017,2,4,12,33,13),
                            Decizia = new Decizie()
                                        {
                                            Denumire = "Ordonanta", Id = 1
                                        },
                            Etapa = new Etapa()
                                        {
                                            Id = 1, Denumire = "Confiscare"
                                        },
                            InstitutiaEmitenta = new Institutie()
                            {
                                Id = 2, Denumire = "Curtea cutare", Categorie = new Categorie(){ Id = 13, Cod="Curte", Descriere = "Curte"}
                            }
                        }
                    }
                }
            };
            return await Task.FromResult(lst);
        }
    }
}
