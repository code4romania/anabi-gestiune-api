using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace Anabi.DataAccess.Ef
{
    public static class DbInitializer
    {
        private static readonly string INSTITUTION_FILE_PATH = Environment.CurrentDirectory;
        
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
            AddInstitutions(context);
            AddIdentifiers(context);
        }

        private static void AddInstitutions(AnabiContext context)
        {
            var categoryForInstitutionId = context.Categories.Where(c => c.ForEntity == "institutie" && c.Code == "Instanta").FirstOrDefault()?.Id;

            var insitutions = new []
            {
                new InstitutionDb
                {
                    Name = "Curtea de Apel Alba Iulia",
                    ContactData = "Some contact here",
                    AddedDate = DateTime.Now,
                    UserCodeAdd = "admin",
                }               
            };
            context.Institutions.AddRange(insitutions);
            context.SaveChanges();
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
            var utilizatori = new[]
            {
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
                new DecisionDb {Name = "Hotarare", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new DecisionDb {Name = "Ordonanta", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new DecisionDb {Name = "Adresa", UserCodeAdd = "admin", AddedDate = DateTime.Now}

            };
            context.Decisions.AddRange(decizii);
            context.SaveChanges();
        }

        public static void AddStages(AnabiContext context)
        {
            var etape = new[]
            {
                new StageDb {Name = "Confiscare", IsFinal = false, StageCategory = Common.Enums.StageCategory.Confiscation, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new StageDb {Name = "Valorificare anticipata", IsFinal = true, StageCategory = Common.Enums.StageCategory.Recovery, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new StageDb {Name = "Sechestru", IsFinal = false, StageCategory = Common.Enums.StageCategory.Sequester, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new StageDb {Name = "Valorificare standard", IsFinal = true, StageCategory = Common.Enums.StageCategory.Recovery, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new StageDb {Name = "Ridicare sechestru", IsFinal = false, StageCategory = Common.Enums.StageCategory.LiftingSeizure, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new StageDb {Name = "Reutilizare sociala", IsFinal = false, StageCategory = Common.Enums.StageCategory.SocialReuse, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new StageDb {Name = "Administrare simpla", IsFinal = false, StageCategory = Common.Enums.StageCategory.SimpleAdministration, UserCodeAdd = "admin", AddedDate = DateTime.Now},
            };
            context.Stages.AddRange(etape);
            context.SaveChanges();
        }

        public static void AddCategories(AnabiContext context)
        {
            var mobile = new CategoryDb {ForEntity = "bun", Code = "Bunuri Mobile",
                Description = "Bunuri care pot fi ridicate", UserCodeAdd = "admin", AddedDate = DateTime.Now};
            context.Categories.Add(mobile);
            context.SaveChanges();
            var idBunuriMobile = mobile.Id;

            var imobile  = new CategoryDb {ForEntity ="bun", Code = "Bunuri Imobile",
                Description = "Bunuri care nu pot fi ridicate",
                UserCodeAdd = "admin",
                AddedDate = DateTime.Now
            };
            context.Categories.Add(imobile);
            context.SaveChanges();
            var idBunuriImobile = imobile.Id;

            var bani = new CategoryDb {ForEntity ="bun", Code ="Bani", Description ="Bani", UserCodeAdd = "admin", AddedDate = DateTime.Now };
            context.Categories.Add(bani);
            context.SaveChanges();
            var idBani = bani.Id;

            var categorii = new[]
            {
                new CategoryDb {ForEntity ="institutie", Code ="Instanta", Description ="", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "institutie", Code ="Parchet", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                //Subcategorii
                new CategoryDb {ForEntity = "bun", Code = "Autovehicule", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Autoutilitare", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Aparate de zbor", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Ambarcatiuni", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Actiuni si parti sociale", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Bunuri accizabile", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Textile", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Masa lemnoasa", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Aparatura electronica si electrocasnica", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Telefonie mobila", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Animale", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Bunuri IT", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Creante", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Aur, bijuterii si metale pretioase", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Echipamente", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Instalatii", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Droguri", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Arme si munitie", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Articole pirotehnice", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Corpuri delicte", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Alte bunuri mobile", ParentId = idBunuriMobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},

                new CategoryDb {ForEntity = "bun", Code = "Apartamente", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Casa", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Casa cu teren", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Casa cu anexa", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Casa cu teren si anexa", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Teren", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Teren cu constructie", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Teren cu anexa", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Teren cu constructie si anexa", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Bloc de locuinte", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Constructie", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Cladire", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Garaj/Parcare", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Restaurant/Motel/Hotel/Pensiuni", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Spatiu comercial", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Alte bunuri imobile", ParentId = idBunuriImobile, UserCodeAdd = "admin", AddedDate = DateTime.Now},

                new CategoryDb {ForEntity = "bun", Code = "Conturi", ParentId = idBani, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Moneda virtuala", ParentId = idBani, UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CategoryDb {ForEntity = "bun", Code = "Cash", ParentId = idBani, UserCodeAdd = "admin", AddedDate = DateTime.Now}
            };

            context.Categories.AddRange(categorii);
            context.SaveChanges();
        }

        public static void AddCounties(AnabiContext context)
        {
            var judete = new[]
            {
                new CountyDb {Abreviation = "AB", Name = "ALBA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "AR", Name= "ARAD", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "AG", Name = "ARGEȘ", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "BC", Name = "BACĂU", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "BH", Name = "BIHOR", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "BN", Name = "BISTRIȚA-NĂSĂUD", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "BT", Name= "BOTOȘANI", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "BV", Name = "BRAȘOV", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "BR", Name = "BRĂILA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "B", Name = "BUCUREȘTI", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "BZ", Name = "BUZĂU", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "CS", Name = "CARAȘ-SEVERIN", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "CL", Name = "CĂLĂRAȘI", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "CJ", Name= "CLUJ", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "CT", Name = "CONSTANȚA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "CV", Name = "COVASNA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "DB", Name = "DÂMBOVIȚA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "DJ", Name = "DOLJ", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "GL", Name= "GALAȚI", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "GR", Name= "GIURGIU", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "GJ", Name = "GORJ", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "HR", Name = "HARGHITA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "HD", Name = "HUNEDOARA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "IL", Name = "IALOMIȚA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "IS", Name= "IAȘI", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "IF", Name = "ILFOV", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "MM", Name = "MARAMUREȘ", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "MH", Name = "MEHEDINȚI", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "MS", Name = "MUREȘ", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "NT", Name= "NEAMȚ", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "OT", Name = "OLT", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "PH", Name = "PRAHOVA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "SM", Name = "SATU MARE", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "SJ", Name = "SĂLAJ", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "SB", Name= "SIBIU", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "SV", Name = "SUCEAVA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "TR", Name = "TELEORMAN", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "TM", Name = "TIMIȘ", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "TL", Name = "TULCEA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "VS", Name= "VASLUI", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "VL", Name = "VÂLCEA", UserCodeAdd = "admin", AddedDate = DateTime.Now},
                new CountyDb {Abreviation = "VN", Name = "VRANCEA", UserCodeAdd = "admin", AddedDate = DateTime.Now}                                              
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

        public static void AddIdentifiers(AnabiContext context)
        {
            var identifiers = new[]
            {
                new IdentifierDb {IdentifierType = "Pasaport", IsForPerson = true, AddedDate = DateTime.Now, UserCodeAdd = "admin" },
                new IdentifierDb {IdentifierType = "CI", IsForPerson = true, AddedDate = DateTime.Now, UserCodeAdd = "admin" },
                new IdentifierDb {IdentifierType = "CUI", IsForPerson = false, AddedDate = DateTime.Now, UserCodeAdd = "admin" },
            };
            context.Identifiers.AddRange(identifiers);
            context.SaveChanges();
        }
    }
}
