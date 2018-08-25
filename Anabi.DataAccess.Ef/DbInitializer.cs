using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Anabi.DataAccess.Ef
{
    public static class DbInitializer
    {
        public static void Initialize(AnabiContext context)
        {
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

            //AdaugaInstitutii(context);

            AdaugaInfractiuni(context);
        }

        private static void AdaugaInfractiuni(AnabiContext context)
        {
            var infractiuni = new[] 
            {
                new CrimeTypeDb{CrimeName = "Furt calificat"},
                new CrimeTypeDb{CrimeName = "Spalare bani"},
                new CrimeTypeDb{CrimeName = "Coruptie"},
                new CrimeTypeDb{CrimeName = "Altele"} 
            };
            context.CrimeTypes.AddRange(infractiuni);
            context.SaveChanges();
        }

        private static void AdaugaInstitutii(AnabiContext context)
        {
            var institutii = new[] {new InstitutionDb{Name = "Nume Institutie"}};
            context.Institutions.AddRange(institutii);
            context.SaveChanges();
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
            var mobile = new CategoryDb {ForEntity = "bun", Code = "Bunuri Mobile", Description = "Bunuri care pot fi ridicate"};
            context.Categories.Add(mobile);
            context.SaveChanges();
            var idBunuriMobile = mobile.Id;

            var imobile  = new CategoryDb {ForEntity ="bun", Code = "Bunuri Imobile", Description = "Bunuri care nu pot fi ridicate"};
            context.Categories.Add(imobile);
            context.SaveChanges();
            var idBunuriImobile = imobile.Id;

            var bani = new CategoryDb {ForEntity ="bun", Code ="Bani", Description ="Bani"};
            context.Categories.Add(bani);
            context.SaveChanges();
            var idBani = bani.Id;

            var categorii = new[]
                        {
                new CategoryDb {ForEntity ="institutie", Code ="Instanta", Description =""},
                new CategoryDb {ForEntity = "institutie", Code ="Parchet"},
                //Subcategorii
                new CategoryDb {ForEntity = "bun", Code = "Autovehicule", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Autoutilitare", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Aparate de zbor", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Ambarcatiuni", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Actiuni si parti sociale", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Bunuri accizabile", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Textile", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Masa lemnoasa", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Aparatura electronica si electrocasnica", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Telefonie mobila", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Animale", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Bunuri IT", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Creante", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Aur, bijuterii si metale pretioase", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Echipamente", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Instalatii", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Droguri", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Arme si munitie", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Articole pirotehnice", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Corpuri delicte", ParentId = idBunuriMobile},
                new CategoryDb {ForEntity = "bun", Code = "Alte bunuri mobile", ParentId = idBunuriMobile},

                new CategoryDb {ForEntity = "bun", Code = "Apartamente", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Casa", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Casa cu teren", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Casa cu anexa", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Casa cu teren si anexa", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Teren", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Teren cu constructie", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Teren cu anexa", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Teren cu constructie si anexa", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Bloc de locuinte", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Constructie", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Cladire", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Garaj/Parcare", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Restaurant/Motel/Hotel/Pensiuni", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Spatiu comercial", ParentId = idBunuriImobile},
                new CategoryDb {ForEntity = "bun", Code = "Alte bunuri imobile", ParentId = idBunuriImobile},

                new CategoryDb {ForEntity = "bun", Code = "Conturi", ParentId = idBani},
                new CategoryDb {ForEntity = "bun", Code = "Moneda virtuala", ParentId = idBani},
                new CategoryDb {ForEntity = "bun", Code = "Cash", ParentId = idBani}
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
