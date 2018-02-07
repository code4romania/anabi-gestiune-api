using Anabi;
using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Features.Assets;
using Anabi.Features.Assets.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AnabiControllers.Tests
{
    [TestClass]
    public class AssetsControllerTests
    {

        private AnabiContext context;
        
        private IMapper mapper;



        [TestMethod]
        public async Task GetStages_ExpectedSeveralStages()
        {
            Setup();

            var queryHandler = new GetStagesHandler(context, mapper);

            var query = new GetStages();

            var actual = await queryHandler.Handle(query);

            Assert.IsTrue(actual.Count > 0);
        }


        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);

            AddStages();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperMappings>();
            });
            mapper = Mapper.Instance;
        }

        private DbContextOptions<AnabiContext> GetContextOptions()
        {
            return new DbContextOptionsBuilder<AnabiContext>()
                            .UseInMemoryDatabase(databaseName: "AnabiInMemory")
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

            this.context.Etape.Add(stage1);
            this.context.Etape.Add(stage2);

            context.SaveChanges();
        }

    }
}
