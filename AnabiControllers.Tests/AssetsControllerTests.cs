using Anabi;
using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Features.Assets;
using Anabi.Features.Assets.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using Anabi.Domain;
using System.Threading;
namespace AnabiControllers.Tests
{
    [TestClass]
    public class AssetsControllerTests
    {
        private const int AssetId = 1;
        private const int EmptyAddressAssetId = 2;

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
        public async Task GetParentCategories_Expected2Categories()
        {
            var queryHandler = new GetCategoriesHandler(BasicNeeds);
            var query = new GetCategories() { ParentsOnly = true };

            var actual = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsTrue(actual.Count == 2);
        }

        [TestMethod]
        public async Task GetSubCategories_Expected2Categories()
        {
            var queryHandler = new GetCategoriesHandler(BasicNeeds);
            var query = new GetCategories() { ParentsOnly = false, ParentId = 1 };

            var actual = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsTrue(actual.Count == 2);
        }


        [TestMethod]
        public async Task GetStages_ExpectedSeveralStages()
        {
            var queryHandler = new GetStagesHandler(BasicNeeds);

            var query = new GetStages();

            var actual = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsTrue(actual.Count > 0);
        }

        [TestMethod]
        public async Task GetAssets_ExpectedResultContainsAddress()
        {
            var queryHandler = new GetAssetHandler(BasicNeeds);

            var query = new GetAssetDetails { Id = AssetId };

            var actual = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Id);
            Assert.IsNotNull(actual.Address);
            Assert.AreEqual("test street name", actual.Address.Street);
            Assert.AreEqual("Barcelona", actual.Address.City);
        }
        
        [TestMethod]
        public async Task GetAssets_ExpectedResultContainsEmptyAddress()
        {
            var queryHandler = new GetAssetHandler(BasicNeeds);

            var query = new GetAssetDetails { Id = EmptyAddressAssetId };

            var actual = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Id);
            Assert.IsNull(actual.Address);
        }

        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);

            AddStages();
            AddCategories();
            AddAssets();

           
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

        private void AddStages()
        {
            var stage1 = new StageDb()
            {
                IsFinal = true,
                Description = "desc 1",
                Name = "Stage 1"
            };

            var stage2 = new StageDb()
            {
                IsFinal = true,
                Description = "desc 2",
                Name = "Stage 2"
            };

            this.context.Stages.Add(stage1);
            this.context.Stages.Add(stage2);

            context.SaveChanges();
        }

        private void AddCategories()
        {
            var parent1 = new CategoryDb()
            {
                Code = "Parent 1",
                ForEntity = "bun"
            };
            var parent2 = new CategoryDb()
            {
                Code = "Parent 2",
                ForEntity = "bun"
            };
            var parent3 = new CategoryDb()
            {
                Code = "Parent 3",
                ForEntity = "ceva"
            };


            context.Categories.Add(parent1);
            context.Categories.Add(parent2);
            context.Categories.Add(parent3);
            context.SaveChanges();

            var children = new List<CategoryDb> {
             new CategoryDb()
            {
                Code = "Child 1",
                ForEntity = "bun",
                ParentId = 1
            },
            new CategoryDb()
            {
                Code = "Child 2",
                ForEntity = "bun",
                ParentId = 1
            },
            new CategoryDb()
            {
                Code = "Child 3",
                ForEntity = "ceva",
                ParentId = 3
            }
        };

            context.Categories.AddRange(children);
            context.SaveChanges();
        }

        private void AddAssets()
        {
            Console.Out.WriteLine("running add assets");
            var asset1 = new AssetDb()
            {
                Id = AssetId,
                Address = new AddressDb()
                {
                    Street = "test street name",
                    City = "Barcelona"
                }
            };
            var historicalStageDb1 = new HistoricalStageDb()
            {
                AddedDate = DateTime.Now,
                UserCodeAdd = "test user code",
                Asset = asset1
            };
            var asset2 = new AssetDb()
            {
                Id = EmptyAddressAssetId
            };
            var historicalStageDb2 = new HistoricalStageDb()
            {
                AddedDate = DateTime.Now,
                UserCodeAdd = "test user code",
                Asset = asset2
            };
            context.Assets.Add(asset1);
            context.Assets.Add(asset2);
            context.HistoricalStages.Add(historicalStageDb1);
            context.HistoricalStages.Add(historicalStageDb2);
            context.SaveChanges();
        }
    }
}
