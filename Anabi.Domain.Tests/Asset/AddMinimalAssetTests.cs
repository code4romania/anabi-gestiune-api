using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Asset;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Tests.Asset
{
    [TestClass]
    public class AddMinimalAssetTests
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
        public async Task AddMinimalAsset_ReturnsCorrectStageId()
        {
            var handler = new AssetHandler(BasicNeeds);
            var stageId = 100;
            var result = await handler.Handle(new Domain.Asset.Commands.AddMinimalAsset
            {
                StageId = stageId,
            }, CancellationToken.None);

            Assert.AreEqual(result.StageId, stageId);
        }

        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);

            AddAdminUser();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperMappings>();
            });
            mapper = Mapper.Instance;
            principal = Utils.TestAuthentificatedPrincipal();
        }


        private void AddAdminUser()
        {
            var userDb = new UserDb()
            {
                UserCode = "admin",
                IsActive = true,
                Email = "admin@test.com",
                Name = "Admin",
                Password = "pass",
                Role = "admin",
                Salt = "salt"
            };

            this.context.Users.Add(userDb);
            this.context.SaveChanges();
        }

        private DbContextOptions<AnabiContext> GetContextOptions()
        {
            return new DbContextOptionsBuilder<AnabiContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .Options;
        }
    }
}
