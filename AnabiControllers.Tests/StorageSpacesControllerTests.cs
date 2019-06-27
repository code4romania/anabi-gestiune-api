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
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using Anabi.Domain;
using System.Threading;
using System.Linq;

namespace AnabiControllers.Tests
{
    [TestClass]
    public class StorageSpacesControllerTests
    {
        private AnabiContext context;
        private List<StorageSpaceDb> storageSpacesForDb;
        private IMapper mapper;
        private IPrincipal principal;
        private BaseHandlerNeeds BasicNeeds => new BaseHandlerNeeds(context, mapper, principal);

        [TestInitialize]
        public void Initialize()
        {
            Setup();
        }

        [TestCleanup]
        public void CleanUp()
        {
            context.Dispose();
            context = null;
            mapper = null;
            Mapper.Reset();
        }

        [TestMethod]
        public async Task Get_ReturnsListAsync()
        {
            var queryHandler = new StorageSpaceQueryHandler(BasicNeeds);
            var query = new GetStorageSpace() { Id = null };
            var actual = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsTrue(actual.Count == 2);
        }

        [TestMethod]
        public async Task Post()
        {
            var queryHandler = new StorageSpaceHandler(BasicNeeds);
            var query = new AddStorageSpace()
            {
                Name = "S1",
                Details = "description",
                CountyCode = "MH",
                Street = "Iancului 33",
                Building = "11",
                City = "Drobeta Turnu Severin",
                StorageSpaceType = Anabi.Common.Enums.StorageSpaceTypeEnum.Defendant
            };
            await queryHandler.Handle(query, CancellationToken.None);
            var cat = await context.StorageSpaces.FirstOrDefaultAsync<StorageSpaceDb>(p => p.Name == "S1");

            Assert.IsNotNull(cat);
        }

        [TestMethod]
        public async Task Put()
        {
            var queryHandler = new StorageSpaceHandler(BasicNeeds);
            var sp = context.StorageSpaces.First();
            var query = new EditStorageSpace()
            {
                Id = sp.Id,
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
            };

            await queryHandler.Handle(query, CancellationToken.None);
            var cat = await context.StorageSpaces.FirstAsync<StorageSpaceDb>(p => p.Id == sp.Id);

            Assert.IsTrue(cat.Name == "S1");
        }

        [TestMethod]
        public async Task Delete()
        {
            var handler = new StorageSpaceHandler(BasicNeeds);
            var sp = context.StorageSpaces.First();
            var query = new DeleteStorageSpace
            {
                Id = sp.Id,
            };
            await handler.Handle(query, CancellationToken.None);
            var cat = await context.StorageSpaces.AnyAsync<StorageSpaceDb>(p => p.Id == sp.Id);

            Assert.IsFalse(cat);
        }

        #region Setup
        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);
            storageSpacesForDb = GetStorageSpacesForDb();
            context.StorageSpaces.AddRange(storageSpacesForDb);
            context.SaveChanges();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperMappings>();

            });
            mapper = Mapper.Instance;
            principal = Utils.TestAuthentificatedPrincipal();
        }

        private List<StorageSpaceDb> GetStorageSpacesForDb()
        {
            return new List<StorageSpaceDb>()
            {
                new StorageSpaceDb
                {
                    Id = 0, Name="Storage 1",
                    Description ="description",
                    Address = new AddressDb{
                    City = "Bucuresti",
                    Building = "Cladire 1",
                    County = new CountyDb
                    {
                        Abreviation = "B",
                        Name = "Bucuresti"
                    },
                    Street = "Sos Pantelimon 11"

                } },
                new StorageSpaceDb
                {
                    Id = 0, Name="Storage 2",
                    Description ="description 22",
                    Address = new AddressDb
                    {
                        City = "Bucuresti",
                        Building = "Cladire 2",
                        County = new CountyDb
                        {
                            Abreviation = "BC",
                            Name = "Bacau"
                        },
                        Street = "Sos Pantelimon 44"
                    }}
            };
        }

        private DbContextOptions<AnabiContext> GetContextOptions()
        {
            return new DbContextOptionsBuilder<AnabiContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .Options;
        }
        #endregion
    }
}
