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

            AdaugaJudete(context);

            AdaugaAdrese(context);
            AdaugaCategorii(context);
            AdaugaEtape(context);
            AdaugareDecizii(context);
            AdaugaEtapePentruDecizii(context);
            AdaugaInstitutii(context);
            AdaugaPersoane(context);

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
