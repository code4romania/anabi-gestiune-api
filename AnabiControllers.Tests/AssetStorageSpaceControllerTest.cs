using Anabi;
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

namespace AnabiControllers.Tests
{
    [TestClass]
    public class AssetStorageSpaceControllerTest
    {
        private AnabiContext context;
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
        public async Task AddAssetStorageSpace()
        {
            var queryHandler = new AssetStorageSpaceHandler(BasicNeeds);
            var entity = new AddAssetStorageSpace
            {
                AssetId = 1002,
                EntryDate = DateTime.Now,
                StorageSpaceId = 1
            };

            await queryHandler.Handle(entity, CancellationToken.None);

            var cat = await context.AssetStorageSpaces.FirstOrDefaultAsync(a => a.Id == 1);

            Assert.IsNotNull(cat);
        }

        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);
            context.SaveChanges();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperMappings>();

            });
            mapper = Mapper.Instance;
            principal = Utils.TestAuthentificatedPrincipal();
        }

        private DbContextOptions<AnabiContext> GetContextOptions()
        {
            return new DbContextOptionsBuilder<AnabiContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .Options;
        }
    }
}
