using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Anabi.DataAccess.Ef
{
    public static class DbInitializer
    {
        public static void InitializeFullDb(AnabiContext context)
        {
            if (context.Counties.Any())
            {
                return; // DB has been seeded
            }


            AddCounties(context);
            AddCategories(context);
            AddStages(context);
            AddDecisions(context);


            AddUsers(context);


            AddRecoveryBeneficiaries(context);


            AddCrimeTypes(context);
        }

        public static void AddCrimeTypes(AnabiContext context)
        {
            var infractiuni = new[] 
            {
                new CrimeTypeDb{CrimeName = "Furt calificat", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CrimeTypeDb{CrimeName = "Spalare bani", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CrimeTypeDb{CrimeName = "Coruptie", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CrimeTypeDb{CrimeName = "Altele", UserCodeAdd = "admin", AddedDate = DateTime.Now} 
            };
            context.CrimeTypes.AddRange(infractiuni);
            context.SaveChanges();
        }

                

        public static void AddUsers(AnabiContext context)
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
                new UserDb()
                {
                    UserCode = "admin",
                    IsActive = true,
                    Email = "admin@test.com",
                    Name = "Admin",
                    Password = "pass",
                    Role = "admin",
                    Salt = "salt"
                }

            };
            context.Users.AddRange(utilizatori);
            context.SaveChanges();
        }


        public static void AddDecisions(AnabiContext context)
        {
            var decizii = new[]
                        {
                new DecisionDb {Name = "Hotarare"},
                new DecisionDb {Name = "Ordonanta"}
                        };
            context.Decisions.AddRange(decizii);
            context.SaveChanges();
        }

        public static void AddStages(AnabiContext context)
        {
            var etape = new[]
                        {
                new StageDb {Name = "Confiscare", IsFinal = false, StageCategory = Common.Enums.StageCategory.Confiscation},
                new StageDb {Name = "Valorificare anticipata", IsFinal = true, StageCategory = Common.Enums.StageCategory.Recovery},
                new StageDb {Name = "Sechestru", IsFinal = false, StageCategory = Common.Enums.StageCategory.Sequester},
                new StageDb {Name = "Valorificare standard", IsFinal = true, StageCategory = Common.Enums.StageCategory.Recovery},
                new StageDb {Name = "Ridicare sechestru", IsFinal = false, StageCategory = Common.Enums.StageCategory.LiftingSeizure},
                new StageDb {Name = "Reutilizare sociala", IsFinal = false, StageCategory = Common.Enums.StageCategory.SocialReuse},
                new StageDb {Name = "Administrare simpla", IsFinal = false, StageCategory = Common.Enums.StageCategory.SimpleAdministration},
                        };
            context.Stages.AddRange(etape);
            context.SaveChanges();
        }

        public static void AddCategories(AnabiContext context)
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

        public static void AddCounties(AnabiContext context)
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

        public static void AddRecoveryBeneficiaries(AnabiContext context)
        {

            var beneficiari = new[]
                    {
                new RecoveryBeneficiaryDb {Name = "Ministerul Educaţiei Naţionale şi Cercetării Ştiinţifice", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new RecoveryBeneficiaryDb {Name = "Ministerul Sănătăţii", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new RecoveryBeneficiaryDb {Name = "Ministerul Afacerilor Interne", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new RecoveryBeneficiaryDb {Name = "Ministerul Public", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new RecoveryBeneficiaryDb {Name = "Ministerul Justiţiei", UserCodeAdd = "admin", AddedDate = DateTime.Now},

                    };
            context.RecoveryBeneficiaries.AddRange(beneficiari);
            context.SaveChanges();

        }
    }
}
