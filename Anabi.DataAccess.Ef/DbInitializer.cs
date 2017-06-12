using Anabi.DataAccess.Ef.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anabi.DataAccess.Ef
{
    public static class DbInitializer
    {
        public static void Initialize(AnabiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Adrese.Any())
            {
                return; // DB has been seeded
            }

            AdaugaUtilizatori(context);

            AdaugaJudete(context);

            AdaugaAdrese(context);
            AdaugaCategorii(context);
            AdaugaEtape(context);
            AdaugareDecizii(context);
            AdaugaEtapePentruDecizii(context);
            AdaugaInstitutii(context);
            AdaugaPersoane(context);

            AdaugaDosareSiNumere(context);



            AdaugaInculpatiDosare(context);

            AdaugaBun(context);

            AdaugaEtapeIstorice(context);

            AdaugaBunuriDosare(context);
            AdaugaSpatiiStocare(context);

        }

        private static void AdaugaSpatiiStocare(AnabiContext context)
        {
            var spatiiStocare = new SpatiuStocareDb[]
                        {
                new SpatiuStocareDb()
                {
                    AdresaId = 1,
                    Denumire = "Spatiul de stocare 1"

                },
                new SpatiuStocareDb()
                {
                    AdresaId =2,
                    Denumire = "Spatiul de stocare 2"
                }
                        };
            context.SpatiiStocare.AddRange(spatiiStocare);
            context.SaveChanges();
        }

        private static void AdaugaUtilizatori(AnabiContext context)
        {
            var utilizatori = new UtilizatorDb[]{

                new UtilizatorDb()
                {
                    CodUtilizator = "pop",
                    Email="pop@gmailx.com",
                    Nume = "Pop Mihai",
                    Rol = "Admin",
                    EsteActiv = true

                },
                new UtilizatorDb()
                {
                    CodUtilizator = "maria",
                    Email="maria@gmailx.com",
                    Nume = "Maria Ionesc",
                    Rol = "SuperUser",
                    EsteActiv = true

                }
            };
            context.Utilizatori.AddRange(utilizatori);
            context.SaveChanges();
        }

        private static void AdaugaBunuriDosare(AnabiContext context)
        {
            var bunuriDosare = new BunuriDosarDb[]
            {
                new BunuriDosarDb()
                {
                    BunId = 1,
                    DosarId = 1,
                    CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,2,3),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 5)
                },
                new BunuriDosarDb()
                {
                    BunId = 2,
                    DosarId = 2,
                    CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,4,3),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 25)
                }
            };
            context.BunuriDosare.AddRange(bunuriDosare);
            context.SaveChanges();
        }

        private static void AdaugaBun(AnabiContext context)
        {
            var bunuri = new BunDb[]
            {
                new BunDb()
                {
                    AdresaId = 1,
                    CategorieId = 1,
                    EtapaCurentaId = 1,
                    DecizieId = 1,
                    EsteSters = false,
                    CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,2,3),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 5)
                },
                new BunDb()
                {
                    AdresaId = 2,
                    CategorieId = 2,
                    EtapaCurentaId = 1,
                    DecizieId = 1,
                    EsteSters = false,
                    CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,3,5),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 15)
                }
            };
            context.Bunuri.AddRange(bunuri);
            context.SaveChanges();
        }

        private static void AdaugaEtapeIstorice(AnabiContext context)
        {
            var etapeIstorice = new EtapaIstoricaDb[]
                        {
                new EtapaIstoricaDb()
                {
                    BunId = 1, EtapaId = 1, DecizieId = 1, InstitutieId = 1,
                    ValoareEstimata = 132000,
                    ValutaEstimare = "EUR",
                    CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,2,3),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 5),
                    TemeiJuridic = "Temei serios",
                    NumarDecizie = "12312AA",
                    DataDeciziei = new DateTime(2017,2,5)
                },
                new EtapaIstoricaDb()
                {
                     BunId = 2, EtapaId = 2, DecizieId = 2, InstitutieId = 1,
                    ValoareEstimata = 176000,
                    ValutaEstimare = "USD",
                    CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,2,3),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 5),
                    TemeiJuridic = "Temei serios 2",
                    NumarDecizie = "12877HH",
                    DataDeciziei = new DateTime(2017,4,6)
                }
                        };
            context.EtapeIstorice.AddRange(etapeIstorice);
            context.SaveChanges();
        }

        private static void AdaugaInculpatiDosare(AnabiContext context)
        {
            var inculpatiDosar = new InculpatiDosarDb[]
            {
                new InculpatiDosarDb(){PersoanaId = 1, DosarId = 1, CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,2,3),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 5)},

                new InculpatiDosarDb()
                {
                    PersoanaId = 2, DosarId = 2, CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,2,3),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 5)
                }
            };
            context.InculpatiDosar.AddRange(inculpatiDosar);
            context.SaveChanges();
        }

        private static void AdaugaDosareSiNumere(AnabiContext context)
        {

            var dosare = new DosarDb[]
        {
                new DosarDb()
                {
                    //NumarDosarInitialId = 1,
                    NumarInitial = new NumarDosarDb(){ NrDosar = "Z100000", InstitutieId = 1, DataNumarului = new DateTime(2017, 2,3), CodUtilizatorAdaugare = "pop", DataAdaugare = new DateTime(2017, 2,5)},
                    NumarDosarInitial = "Z100000",

                    //NumarDosarCurentId = 2,
                    NumarCurent = new NumarDosarDb(){ NrDosar = "XC3450000", InstitutieId = 2, DataNumarului = new DateTime(2017, 4,5), CodUtilizatorAdaugare = "pop", DataAdaugare = new DateTime(2017, 4,8)},
                    NumarDosarCurent = "XC3450000",

                    Prejudiciu = 145000,
                    ValutaPrejudiciu = "EUR",
                    IncadrareJuridica = "Spalare de bani",
                    DomeniuInfractional = "Frauda",

                    CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,2,3),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 5)
                },
                new DosarDb()
                {
                    NumarDosarInitialId = 3,
                    NumarInitial = new NumarDosarDb(){ NrDosar = "T450000", InstitutieId = 1, DataNumarului = new DateTime(2017, 2,3), CodUtilizatorAdaugare = "pop", DataAdaugare = new DateTime(2017, 2,5)},
                    NumarDosarInitial = "T450000",

                    NumarDosarCurentId = 4,
                    NumarCurent = new NumarDosarDb(){ NrDosar = "Y644009", InstitutieId = 2, DataNumarului = new DateTime(2017, 4,5), CodUtilizatorAdaugare = "pop", DataAdaugare = new DateTime(2017, 4,8)},
                    NumarDosarCurent = "Y644009",

                    Prejudiciu = 356000,
                    ValutaPrejudiciu = "USD",
                    IncadrareJuridica = "Evaziune fiscala",
                    DomeniuInfractional = "Frauda",

                    CodUtilizatorAdaugare = "pop",
                    DataAdaugare = new DateTime(2017,2,3),
                    CodUtilizatorUltimaModificare = "maria",
                    DataUltimeiModificari = new DateTime(2017, 4, 5)
                }
        };
            context.Dosare.AddRange(dosare);
            context.SaveChanges();


            


        }

        private static void AdaugaPersoane(AnabiContext context)
        {
            var persoane = new PersoanaDb[]
                        {
                new PersoanaDb(){Denumire = "Popescu Gigi", EstePf = true, Identificator = "11122336658", AdresaId = 1, CodUtilizatorAdaugare="pop", DataAdaugare = new DateTime(2017, 1,1), NumarCi ="122345", SerieCi= "RR"},
                new PersoanaDb(){Denumire = "SC Alfa si Omega SRL", EstePf = false, Identificator ="1231123", AdresaId = 2, CodUtilizatorAdaugare="pop", DataAdaugare = new DateTime(2017, 1,1)}
                        };
            context.Persoane.AddRange(persoane);
            context.SaveChanges();
        }

        private static void AdaugaInstitutii(AnabiContext context)
        {
            var institutii = new InstitutieDb[]
                        {
                new InstitutieDb(){AdresaId = 1, CategorieId = 4, CodUtilizatorAdaugare="pop", DataAdaugare = new DateTime(2017,1, 2), Denumire ="Parchetul din Iasi"},
                new InstitutieDb(){AdresaId = 2, CategorieId = 5, CodUtilizatorAdaugare = "pop", DataAdaugare = new DateTime(2017,2,3), Denumire = "Instanta din Craiova"}
                        };
            context.Institutii.AddRange(institutii);
            context.SaveChanges();
        }

        private static void AdaugaEtapePentruDecizii(AnabiContext context)
        {
            var etapePtDecizie = new EtapePentruDecizieDb[]
                        {
                new EtapePentruDecizieDb(){DecizieId = 1, EtapaId = 1},
                new EtapePentruDecizieDb(){DecizieId = 1, EtapaId = 2},
                new EtapePentruDecizieDb(){DecizieId = 1, EtapaId = 3},
                new EtapePentruDecizieDb(){DecizieId = 2, EtapaId = 1},
                new EtapePentruDecizieDb(){DecizieId = 2, EtapaId = 2},
                new EtapePentruDecizieDb(){DecizieId = 2, EtapaId = 3}
                        };
            context.EtapePentruDecizii.AddRange(etapePtDecizie);
            context.SaveChanges();
        }

        private static void AdaugareDecizii(AnabiContext context)
        {
            var decizii = new DecizieDb[]
                        {
                new DecizieDb(){Denumire = "Hotarare"},
                new DecizieDb(){Denumire = "Ordonanta"}
                        };
            context.Decizii.AddRange(decizii);
            context.SaveChanges();
        }

        private static void AdaugaEtape(AnabiContext context)
        {
            var etape = new EtapaDb[]
                        {
                new EtapaDb(){Denumire = "Confiscare", EsteFinala = false},
                new EtapaDb(){Denumire = "Valorificare", EsteFinala = true},
                new EtapaDb(){Denumire = "Sechestru", EsteFinala = false}
                        };
            context.Etape.AddRange(etape);
            context.SaveChanges();
        }

        private static void AdaugaCategorii(AnabiContext context)
        {
            var categorii = new CategorieDb[]
                        {
                new CategorieDb(){PentruEntitate = "bun", Cod = "Bunuri Mobile", Descriere = "Bunuri care pot fi ridicate"},
                new CategorieDb(){PentruEntitate ="bun", Cod = "Bunuri Imobile", Descriere = "Bunuri care nu pot fi ridicate"},
                new CategorieDb(){PentruEntitate ="bun", Cod ="Bani", Descriere ="Bani"},
                new CategorieDb(){PentruEntitate ="institutie", Cod ="Instanta", Descriere =""},
                new CategorieDb(){PentruEntitate = "institutie", Cod ="Parchet"}

                        };
            context.Categorii.AddRange(categorii);
            context.SaveChanges();
        }

        private static void AdaugaAdrese(AnabiContext context)
        {

            var adrese = new AdresaDb[]
                                    {
                new AdresaDb(){Strada = "Pantelimon nr 23", Cladire="Bloc 1", JudetId = 1, Oras="Bucuresti"},
                new AdresaDb(){Strada = "Iancului 22", Cladire="Blco 102S", JudetId = 1, Oras="Bucuresti"},
                new AdresaDb(){Strada = "O strada 22", Cladire="Bloc 13", JudetId = 3, Oras ="Constanta"}
                                    };
            context.Adrese.AddRange(adrese);
            context.SaveChanges();

        }

        private static void AdaugaJudete(AnabiContext context)
        {

            var judete = new JudetDb[]
                    {
                new JudetDb(){Abreviere = "B", Denumire = "Bucuresti"},
                new JudetDb(){Abreviere = "AB", Denumire= "Alba Iulia"},
                new JudetDb(){Abreviere = "CT", Denumire = "Constanta"},
                new JudetDb(){Abreviere = "BV", Denumire = "Brasov"},
                new JudetDb(){Abreviere = "SB", Denumire = "Sibiu"}
                    };
            context.Judete.AddRange(judete);
            context.SaveChanges();

        }
    }
}
