using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Anabi.Functional.Tests
{
    public class AnabiDbContextBuilder
    {
        private AnabiContext context;

        public AnabiDbContextBuilder CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AnabiContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new AnabiContext(options);
            
            return this;
        }

        public AnabiDbContextBuilder WithAssetCategories()
        {
            var mobile = new CategoryDb { ForEntity = "bun", Code = "Bunuri Mobile", Description = "Bunuri care pot fi ridicate" };
            context.Categories.Add(mobile);
            var idBunuriMobile = mobile.Id;

            var imobile = new CategoryDb { ForEntity = "bun", Code = "Bunuri Imobile", Description = "Bunuri care nu pot fi ridicate" };
            context.Categories.Add(imobile);
            var idBunuriImobile = imobile.Id;

            var bani = new CategoryDb { ForEntity = "bun", Code = "Bani", Description = "Bani" };
            context.Categories.Add(bani);
            var idBani = bani.Id;

            context.SaveChanges();

            var childCategories = new[]
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

            context.Categories.AddRange(childCategories);
            context.SaveChanges();

            return this;
        }


        public AnabiContext Build()
        {
            return context;
        }
    }
}
