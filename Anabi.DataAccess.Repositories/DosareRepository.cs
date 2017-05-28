using Anabi.DataAccess.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Anabi.Domain.Core.Models;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;

namespace Anabi.DataAccess.Repositories
{
    public class DosareRepository : BaseRepository, IDosareRepository
    {
        public DosareRepository(AnabiContext ctx)
        {
            context = ctx;
        }
        public async Task<IEnumerable<Dosar>> GetDosareAsync()
        {
            return await getDosareAsync();
        }

        private async Task<IEnumerable<Dosar>> getDosareAsync()
        {
            var lst = new List<Dosar>()
            {
                new Dosar()
                {
                    Id = 1,
                    NumarDosarInitial = "AA123131",
                    NumarInitial = new NumarDosar()
                    {
                        Id = 1, DataNumarului = new DateTime(2017, 1, 3),
                        Instanta = new Institutie()
                        {
                            Id = 2, Denumire = "Parchetul X", Categorie = new Categorie()
                            {
                                Id = 1, Cod = "Parchet", Descriere = "Parchet"
                            }, Adresa = new Adresa()
                        }, NrDosar = "AA123131"
                    },

                    NumarDosarCurent = "BB3550",
                    NumarCurent = new NumarDosar()
                    {
                        Id = 1, DataNumarului = new DateTime(2017, 2, 14),
                        Instanta = new Institutie()
                        {
                            Id = 2, Denumire = "Curtea Y", Categorie = new Categorie()
                            {
                                Id = 1, Cod = "Curte", Descriere = "Curte"
                            }, Adresa = new Adresa()
                        }, NrDosar = "BB3550"
                    },
                    Bunuri = new List<Bun>(),
                    DetaliuJurnal = new DetaliuJurnal(),
                    DomeniuInfractional = "domeniu infractional",
                    IncadrareJuridica = "incadrare juridica",
                    Inculpati = new List<Persoana>(),
                    Numere = new List<NumarDosar>()
                    {
                        new NumarDosar()
                        {
                            Id = 1, DataNumarului = new DateTime(2017, 1, 3),
                            Instanta = new Institutie()
                            {
                                Id = 2, Denumire = "Parchetul X", Categorie = new Categorie()
                                {
                                    Id = 1, Cod = "Parchet", Descriere = "Parchet"
                                }, Adresa = new Adresa()
                            }, NrDosar = "AA123131"
                        },
                            new NumarDosar()
                        {
                            Id = 1, DataNumarului = new DateTime(2017, 2, 14),
                            Instanta = new Institutie()
                            {
                                Id = 2, Denumire = "Curtea Y", Categorie = new Categorie()
                                {
                                    Id = 1, Cod = "Curte", Descriere = "Curte"
                                }, Adresa = new Adresa()
                            }, NrDosar = "BB3550"
                        }
                    },
                    Prejudiciu = 25890, ValutaPrejudiciu = "EUR"
                }
            };

            return await Task.FromResult(lst);
        }
    }
}
