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

            if (context.Judete.Any())
            {
                return; // DB has been seeded
            }

            AdaugaJudete(context);

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
        }
    }
}
