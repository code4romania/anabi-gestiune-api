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


        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);

            AddStages();
            AddCategories();

           
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

    }
}
