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
            AdaugaEtapePentruDecizii(context);


            AdaugaUtilizatori(context);

            AdaugaAdrese(context);

            AdaugaInstitutii(context);
            AdaugaPersoane(context);

            AdaugaDosareSiNumere(context);
            AdaugaInculpatiDosare(context);

            AdaugaBun(context);

            AdaugaEtapeIstorice(context);

            AdaugaBunuriDosare(context);
            AdaugaSpatiiStocare(context);
            AdaugaBunuriSpatiiStocare(context);

            AdaugaBeneficiariValorificari(context);
        }

        private static void AdaugaBunuriSpatiiStocare(AnabiContext context)
        {
            var bunurispatiiStocare = new[]
                        {
                new AssetStorageSpaceDb
                {
                    AssetId = 1,
                    StorageSpaceId = 1,
                    EntryDate = new DateTime(2017,1,3),
                    UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,1,6)
                },
                new AssetStorageSpaceDb
                {
                    AssetId = 2,
                    StorageSpaceId = 2,
                    EntryDate = new DateTime(2017,2,4),
                    UserCodeAdd = "maria",
                    AddedDate = new DateTime(2017,2,8)
                }
                        };
            context.AssetStorageSpaces.AddRange(bunurispatiiStocare);
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

        private static void AdaugaBunuriDosare(AnabiContext context)
        {
            var bunuriDosare = new[]
            {
                new AssetsFileDb
                {
                    AssetId = 1,
                    FileId = 1,
                    UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,2,3),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 5)
                },
                new AssetsFileDb
                {
                    AssetId = 2,
                    FileId = 2,
                    UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,4,3),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 25)
                }
            };
            context.BunuriDosare.AddRange(bunuriDosare);
            context.SaveChanges();
        }

        private static void AdaugaBun(AnabiContext context)
        {
            var bunuri = new[]
            {
                new AssetDb
                {
                    AddressId = 1,
                    CategoryId = 1,

                    DecisionId = 1,
                    IsDeleted = false,
                    UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,2,3),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 5),
                    Identifier = "Demo",
                    NecessaryVolume = 12.2m
                },
                new AssetDb
                {
                    AddressId = 2,
                    CategoryId = 2,

                    DecisionId = 1,
                    IsDeleted = false,
                    UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,3,5),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 15),
                    Identifier = String.Empty,
                    NecessaryVolume = null
                }
            };
            context.Assets.AddRange(bunuri);
            context.SaveChanges();
        }

        private static void AdaugaEtapeIstorice(AnabiContext context)
        {
            var etapeIstorice = new[]
                        {
                new HistoricalStageDb
                {
                    AssetId = 1, StageId = 1, DecizieId = 1, InstitutionId = 1,
                    EstimatedAmount = 132000,
                    EstimatedAmountCurrency = "EUR",
                    UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,2,3),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 5),
                    LegalBasis = "Temei serios",
                    DecisionNumber = "12312AA",
                    DecisionDate = new DateTime(2017,2,5),
                    AssetState = "Super",
                    OwnerId = 2,
                    ActualValue = 5.3m,
                    ActualValueCurrency = "ron"
                },
                new HistoricalStageDb
                {
                    AssetId = 2, StageId = 2, DecizieId = 2, InstitutionId = 1,
                    EstimatedAmount = 176000,
                    EstimatedAmountCurrency = "USD",
                    UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,2,3),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 5),
                    LegalBasis = "Temei serios 2",
                    DecisionNumber = "12877HH",
                    DecisionDate = new DateTime(2017,4,6),
                    AssetState = "Groaznica",
                    OwnerId = null,
                    ActualValue = null,
                    ActualValueCurrency = "usd"
                }
                        };
            context.HistoricalStages.AddRange(etapeIstorice);
            context.SaveChanges();
        }

        private static void AdaugaInculpatiDosare(AnabiContext context)
        {
            var inculpatiDosar = new[]
            {
                new DefendantsFileDb
                {PersonId = 1, FileId = 1, UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,2,3),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 5)},

                new DefendantsFileDb
                {
                    PersonId = 2, FileId = 2, UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,2,3),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 5)
                }
            };
            context.InculpatiDosar.AddRange(inculpatiDosar);
            context.SaveChanges();
        }

        private static void AdaugaDosareSiNumere(AnabiContext context)
        {

            var dosare = new[]
        {
                new FileDb
                {
                    //NumarDosarInitialId = 1,
                    InitialNumber = new FileNumberDb { FileNumber = "Z100000", InstitutionId = 1, NumberDate = new DateTime(2017, 2,3), UserCodeAdd = "pop", AddedDate = new DateTime(2017, 2,5)},
                    InitialFileNumber = "Z100000",

                    //NumarDosarCurentId = 2,
                    CurrentNumber = new FileNumberDb { FileNumber = "XC3450000", InstitutionId = 2, NumberDate = new DateTime(2017, 4,5), UserCodeAdd = "pop", AddedDate = new DateTime(2017, 4,8)},
                    CurrentFileNumber = "XC3450000",

                    DamageAmount = 145000,
                    DamageCurrency = "EUR",
                    LegalClassification = "Spalare de bani",
                    CriminalField = "Frauda",

                    UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,2,3),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 5)
                },
                new FileDb
                {
                    InitialFileId = 3,
                    InitialNumber = new FileNumberDb { FileNumber = "T450000", InstitutionId = 1, NumberDate = new DateTime(2017, 2,3), UserCodeAdd = "pop", AddedDate = new DateTime(2017, 2,5)},
                    InitialFileNumber = "T450000",

                    CurrentFileNumberId = 4,
                    CurrentNumber = new FileNumberDb { FileNumber = "Y644009", InstitutionId = 2, NumberDate = new DateTime(2017, 4,5), UserCodeAdd = "pop", AddedDate = new DateTime(2017, 4,8)},
                    CurrentFileNumber = "Y644009",

                    DamageAmount = 356000,
                    DamageCurrency = "USD",
                    LegalClassification = "Evaziune fiscala",
                    CriminalField = "Frauda",

                    UserCodeAdd = "pop",
                    AddedDate = new DateTime(2017,2,3),
                    UserCodeLastChange = "maria",
                    LastChangeDate = new DateTime(2017, 4, 5)
                }
        };
            context.Dosare.AddRange(dosare);
            context.SaveChanges();





        }

        private static void AdaugaPersoane(AnabiContext context)
        {
            var persoane = new[]
                        {
                new PersonDb {Name = "Popescu Gigi", IsPerson = true, Identification = "11122336658", AddressId = 1, UserCodeAdd="pop", AddedDate = new DateTime(2017, 1,1), IdNumber ="122345", IdSerie= "RR"},
                new PersonDb {Name = "SC Alfa si Omega SRL", IsPerson = false, Identification ="1231123", AddressId = 2, UserCodeAdd="pop", AddedDate = new DateTime(2017, 1,1)}
                        };
            context.Persons.AddRange(persoane);
            context.SaveChanges();
        }

        private static void AdaugaInstitutii(AnabiContext context)
        {
            var institutii = new[]
                        {
                new InstitutionDb {AddressId = 1, CategoryId = 4, UserCodeAdd="pop", AddedDate = new DateTime(2017,1, 2), Name ="Parchetul din Iasi"},
                new InstitutionDb {AddressId = 2, CategoryId = 5, UserCodeAdd = "pop", AddedDate = new DateTime(2017,2,3), Name = "Instanta din Craiova"}
                        };
            context.Institutions.AddRange(institutii);
            context.SaveChanges();
        }

        private static void AdaugaEtapePentruDecizii(AnabiContext context)
        {
            var etapePtDecizie = new[]
                        {
                new StagesForDecisionDb {DecisionId = 1, StageId = 1},
                new StagesForDecisionDb {DecisionId = 1, StageId = 2},
                new StagesForDecisionDb {DecisionId = 1, StageId = 3},
                new StagesForDecisionDb {DecisionId = 2, StageId = 1},
                new StagesForDecisionDb {DecisionId = 2, StageId = 2},
                new StagesForDecisionDb {DecisionId = 2, StageId = 3}
                        };
            context.StagesForDecisions.AddRange(etapePtDecizie);
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

        private static void AdaugaAdrese(AnabiContext context)
        {

            var adrese = new[]
                                    {
                new AddressDb {Street = "Pantelimon nr 23", Building="Bloc 1", CountyId = 1, City="Bucuresti"},
                new AddressDb {Street = "Iancului 22", Building="Blco 102S", CountyId = 1, City="Bucuresti"},
                new AddressDb {Street = "O strada 22", Building="Bloc 13", CountyId = 3, City ="Constanta"}
                                    };
            context.Addresses.AddRange(adrese);
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
