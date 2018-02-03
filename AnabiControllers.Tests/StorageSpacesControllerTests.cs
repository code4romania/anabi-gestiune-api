using Anabi;
using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.StorageSpaces;
using Anabi.Domain.StorageSpaces.Commands;
using Anabi.Features.StorageSpaces;
using Anabi.Features.StorageSpaces.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnabiControllers.Tests
{
    [TestClass]
    public class StorageSpacesControllerTests
    {
        private AnabiContext context;
        private List<StorageSpaceDb> storageSpacesForDb;
        private IMapper mapper;


        [TestMethod]
        public async Task Get_ReturnsListAsync()
        {
            Setup();

            var queryHandler = new StorageSpaceQueryHandler(context, mapper);

            var query = new GetStorageSpace() { Id = null };

            var actual = await queryHandler.Handle(query);

            Assert.IsTrue(actual.Count > 0);
        }


        [TestMethod]
        public async Task Post()
        {

            Setup();

            var queryHandler = new StorageSpaceHandler(context, mapper);
            var query = new AddStorageSpace()
            {
                Name = "S1",
                Width = 2,
                Length = 2,
                Description = "description",
                MaintenanceMentions = "mentenanta",
                ContactData = "contact",
                TotalVolume = 222,
                UndevelopedArea = 22,
                MonthlyMaintenanceCost = 444,
                AsphaltedArea = 222,
                AvailableVolume = 334,
                CountyCode = "B",
                Street = "Iancului 33",
                Building = "11",
                City ="Bucuresti",
                FlatNo = "22",
                Floor = "22",
                Stair = "B"
               
            };

            await queryHandler.Handle(query);

            var cat = await context.SpatiiStocare.FirstOrDefaultAsync<StorageSpaceDb>(p => p.Name == "S1");

            Assert.IsNotNull(cat);

        }



        [TestMethod]
        public async Task Put()
        {
            Setup();

            var queryHandler = new StorageSpaceHandler(context, mapper);

            var query = new EditStorageSpace()
            {
                Id = 1,
                Name = "S1",
                Width = 2,
                Length = 2,
                Description = "description",
                MaintenanceMentions = "mentenanta",
                ContactData = "contact",
                TotalVolume = 222,
                UndevelopedArea = 22,
                MonthlyMaintenanceCost = 444,
                AsphaltedArea = 222,
                AvailableVolume = 334,
                CountyCode = "B",
                Street = "Iancului 33",
                Building = "11",
                City = "Bucuresti",
                FlatNo = "22",
                Floor = "22",
                Stair = "B"
            };

            await queryHandler.Handle(query);

            var cat = await context.SpatiiStocare.FirstAsync<StorageSpaceDb>(p => p.Id == 1);

            Assert.IsTrue(cat.Name == "S1");

        }

        [TestMethod]
        public async Task Delete()
        {
            Setup();
            var handler = new StorageSpaceHandler(context, mapper);

            var query = new DeleteStorageSpace
            {
                Id = 1
            };

            await handler.Handle(query);

            var cat = await context.SpatiiStocare.AnyAsync<StorageSpaceDb>(p => p.Id == 1);

            Assert.IsFalse(cat);
        }



        #region Setup
        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);
            storageSpacesForDb = GetStorageSpacesForDb();

            context.SpatiiStocare.AddRange(storageSpacesForDb);
            context.SaveChanges();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperMappings>();
                
            });
            mapper = Mapper.Instance;
        }

        private List<StorageSpaceDb> GetStorageSpacesForDb()
        {
            return new List<StorageSpaceDb>()
            {
                new StorageSpaceDb{ Id = 0, Name="Storage 1", AsphaltedArea = 22, AvailableVolume =22 , ContactData ="contact data", Description ="description", Length = 2, MaintenanceMentions = "mentiuni", TotalVolume = 22, UndevelopedArea = 222, MonthlyMaintenanceCost = 400, Width = 22
                , Address = new AddressDb{
                    City = "Bucuresti",
                    Building = "Cladire 1",
                    CountyId = 1,
                    Street = "Sos Pantelimon 11"
                    
                } },
                new StorageSpaceDb{ Id = 0, Name="Storage 2", AsphaltedArea = 22322, AvailableVolume =2222 , ContactData ="contact data 22", Description ="description 22", Length = 2, MaintenanceMentions = "mentiuni 2", TotalVolume = 2234, UndevelopedArea = 5642, MonthlyMaintenanceCost = 3330, Width = 332
                , Address = new AddressDb{
                    City = "Bucuresti",
                    Building = "Cladire 2",
                    CountyId = 1,
                    Street = "Sos Pantelimon 44"

                }}
            };
        }

        private DbContextOptions<AnabiContext> GetContextOptions()
        {
            return new DbContextOptionsBuilder<AnabiContext>()
                            .UseInMemoryDatabase(databaseName: "AnabiInMemory")
                            .Options;
        }
        #endregion
    }
}
