using Anabi.DataAccess.Ef.DbModels;
using System;
using System.Linq;

namespace Anabi.DataAccess.Ef
{
    public static class DbInitializer
    {
        public static void Initialize(AnabiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Counties.Any())
            {
                return; // DB has been seeded
            }


            AdaugaJudete(context);
            AdaugaCategorii(context);
            AdaugaEtape(context);
            AdaugareDecizii(context);


            AdaugaUtilizatori(context);

            AdaugaSpatiiStocare(context);

            AdaugaBeneficiariValorificari(context);
        }

        private static void AdaugaSpatiiStocare(AnabiContext context)
        {
            var spatiiStocare = new[]
                        {
                new StorageSpaceDb
                {
                    Address = new AddressDb{
                    City = "Bucuresti",
                    Building = "Cladire 1",
                    CountyId = 1,
                    Street = "Sos Pantelimon 11"

                    },
                    Name = "Spatiul de stocare 1",
                    CategoryId = 1,
                    TotalVolume = 30,
                    AvailableVolume = 2,
                    Length = 2,
                    Width = 2,
                    Description = "Some fairly well preserved good.",
                    AsphaltedArea = 3,
                    UndevelopedArea = 0,
                    ContactData = "95685485",
                    MonthlyMaintenanceCost = 0,
                    MaintenanceMentions = "hope it will not break"
                },
                new StorageSpaceDb
                {
                    Address = new AddressDb{
                    City = "Bucuresti",
                    Building = "Cladire 1",
                    CountyId = 1,
                    Street = "Sos Pantelimon 11"

                },
                    Name = "Spatiul de stocare 2",
                    CategoryId = 1,
                    TotalVolume = 20,
                    AvailableVolume = 2,
                    Length = 2,
                    Width = 2,
                    Description = "Some badly preserved good.",
                    AsphaltedArea = 3,
                    UndevelopedArea = 0,
                    ContactData = "12345679",
                    MonthlyMaintenanceCost = 0,
                    MaintenanceMentions = " it will break"

                }
                        };
            context.StorageSpaces.AddRange(spatiiStocare);
            context.SaveChanges();
        }

        private static void AdaugaUtilizatori(AnabiContext context)
        {
            var utilizatori = new[]{

                new UserDb
                {
                    UserCode = "pop",
                    Email="pop@gmailx.com",
                    Name = "Pop Mihai",
                    Role = "Admin",
                    Password ="12345",
                    Salt = "sarea",
                    IsActive = true

                },
                new UserDb
                {
                    UserCode = "maria",
                    Email="maria@gmailx.com",
                    Name = "Maria Ionescu",
                    Password ="54321",
                    Salt = "sarea",
                    Role = "SuperUser",
                    IsActive = true

                },
                new UserDb
                {
                    UserCode = "admin",
                    Email="admin@gmailx.com",
                    Name = "admin",
                    Password ="$2a$10$McB4.Yuu8zeBaKvd8bHgU.zvg2aXM9l0Gj.gN6hi4xiFv4DsJyPQq",
                    Salt = "sarea",
                    Role = "Admin",
                    IsActive = true

                }
            };
            context.Users.AddRange(utilizatori);
            context.SaveChanges();
        }


        private static void AdaugareDecizii(AnabiContext context)
        {
            var decizii = new[]
                        {
                new DecisionDb {Name = "Hotarare"},
                new DecisionDb {Name = "Ordonanta"}
                        };
            context.Decisions.AddRange(decizii);
            context.SaveChanges();
        }

        private static void AdaugaEtape(AnabiContext context)
        {
            var etape = new[]
                        {
                new StageDb {Name = "Confiscare", IsFinal = false, StageCategory = Common.Enums.StageCategory.Confiscation},
                new StageDb {Name = "Valorificare", IsFinal = true, StageCategory = Common.Enums.StageCategory.Recovery},
                new StageDb {Name = "Sechestru", IsFinal = false, StageCategory = Common.Enums.StageCategory.Sequester}
                        };
            context.Stages.AddRange(etape);
            context.SaveChanges();
        }

        private static void AdaugaCategorii(AnabiContext context)
        {
            var categorii = new[]
                        {
                new CategoryDb {ForEntity = "bun", Code = "Bunuri Mobile", Description = "Bunuri care pot fi ridicate"},
                new CategoryDb {ForEntity ="bun", Code = "Bunuri Imobile", Description = "Bunuri care nu pot fi ridicate"},
                new CategoryDb {ForEntity ="bun", Code ="Bani", Description ="Bani"},
                new CategoryDb {ForEntity ="institutie", Code ="Instanta", Description =""},
                new CategoryDb {ForEntity = "institutie", Code ="Parchet"}

                        };
            context.Categories.AddRange(categorii);
            context.SaveChanges();
        }

        

        private static void AdaugaJudete(AnabiContext context)
        {

            var judete = new[]
                    {
                new CountyDb {Abreviation = "B", Name = "Bucuresti"},
                new CountyDb {Abreviation = "AB", Name= "Alba Iulia"},
                new CountyDb {Abreviation = "CT", Name = "Constanta"},
                new CountyDb {Abreviation = "BV", Name = "Brasov"},
                new CountyDb {Abreviation = "SB", Name = "Sibiu"}
                    };
            context.Counties.AddRange(judete);
            context.SaveChanges();

        }

        private static void AdaugaBeneficiariValorificari(AnabiContext context)
        {

            var beneficiari = new[]
                    {
                new RecoveryBeneficiaryDb {Name = "Ministerul Educaţiei Naţionale şi Cercetării Ştiinţifice"},
                new RecoveryBeneficiaryDb {Name = "Ministerul Sănătăţii"},
                new RecoveryBeneficiaryDb {Name = "Ministerul Afacerilor Interne"},
                new RecoveryBeneficiaryDb {Name = "Ministerul Public"},
                new RecoveryBeneficiaryDb {Name = "Ministerul Justiţiei"},

                    };
            context.RecoveryBeneficiaries.AddRange(beneficiari);
            context.SaveChanges();

        }
    }
}
