using Anabi.DataAccess.Ef;
using Anabi.Domain.Asset.Commands;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Principal;
using System.Threading.Tasks;
using Anabi.Domain;
using System.Threading;
using Anabi.Domain.Asset;
using Anabi.Features.Assets;
using Anabi.Features.Assets.Models;
using AutoFixture;
using System.Linq;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Tests.Common;

namespace AnabiControllers.Tests
{
    [TestClass]
    public class AssetStorageSpaceControllerTest
    {
        private AnabiContext context;
        private IMapper mapper;
        private IPrincipal principal;
        private Fixture fixture;

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
        }

        [TestMethod]
        public async Task ShouldReturnAStoargeSpaceForAsset()
        {
            var entity = await AddAssetToStorageSpace();

            var asset = new AssetDb { Id = entity.AssetId };
            context.Assets.Add(asset);
            var storageSpace = new StorageSpaceDb { Id = entity.StorageSpaceId, Address = new AddressDb { County = new CountyDb() } };
            context.StorageSpaces.Add(storageSpace);
            context.SaveChanges();

            var queryHandler = new GetStorageSpaceAssetHandler(BasicNeeds);
            
            var query = new GetAssetStorageSpace() { AssetId = entity.AssetId};

            var expected = await queryHandler.Handle(query, CancellationToken.None);
            
            Assert.IsTrue(expected.Count > 0);
        }

        [TestMethod]
        public async Task AddAssetStorageSpace()
        {
            var entity = await AddAssetToStorageSpace();

            var combination = context.AssetStorageSpaces.Single();

            Assert.AreEqual(entity.AssetId, combination.AssetId);
            Assert.AreEqual(entity.StorageSpaceId, combination.StorageSpaceId);
        }

        private async Task<AddAssetStorageSpace> AddAssetToStorageSpace()
        {
            var queryHandler = new AssetStorageSpaceHandler(BasicNeeds);
            var entity = fixture.Create<AddAssetStorageSpace>();

            await queryHandler.Handle(entity, CancellationToken.None);
            return entity;
        }

        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);
            context.SaveChanges();

            mapper = MapperCreator.CreateAutomapper();
            principal = PrincipalCreator.TestAuthentificatedPrincipal();
            fixture = new Fixture();
        }

        private DbContextOptions<AnabiContext> GetContextOptions()
        {
            return new DbContextOptionsBuilder<AnabiContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .Options;
        }
    }
}
