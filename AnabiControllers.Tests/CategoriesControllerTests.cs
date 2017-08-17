using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anabi.DataAccess.Ef.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anabi.Features.Dictionaries.Category;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Anabi;

namespace AnabiControllers.Tests
{
    [TestClass]
    public class CategoriesControllerTests
    {
        private AnabiContext context;
        private List<CategoryDb> categoriesForDb;
        private IMapper mapper;

        [TestMethod]
        public async Task Get_ReturnsListAsync()
        {
            Setup();

            var queryHandler = new CategoryQueryHandler(context, mapper);

            var query = new CategoryQuery() { Id = null };

            var actual = await queryHandler.Handle(query);

            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public async Task Post()
        {

            Setup();

            var queryHandler = new AddCategoryQueryHandler(context, mapper);
            var query = new AddCategoryQuery()
            {
                Code = "Code 3",
                Description = "Desc Code 3",
                ForEntity = "Test ent 3",
                Id = 0,
                ParentId = null
            };

            await queryHandler.Handle(query);

            var cat = context.Categorii.FirstAsync<CategoryDb>(p => p.Code == "Code 3");

            Assert.IsNotNull(cat);

        }

        [TestMethod]
        public async Task Put()
        {
            Setup();

            var queryHandler = new EditCategoryQueryHandler(context, mapper);

            var query = new EditCategoryQuery()
            {
                Code = "Code 3",
                Description = "Desc Code 3",
                ForEntity = "Test ent 3",
                Id = 1,
                ParentId = null
            };

            await queryHandler.Handle(query);

            var cat = await context.Categorii.FirstAsync<CategoryDb>(p => p.Code == "Code 3");

            Assert.IsNotNull(cat);

        }

        [TestMethod]
        public async Task Delete()
        {
            Setup();
            var handler = new DeleteCategoryQueryHandler(context, mapper);

            var query = new DeleteCategoryQuery
            {
                Id = 1
            };

            await handler.Handle(query);

            var cat = await context.Categorii.AnyAsync<CategoryDb>(p => p.Id == 1);

            Assert.IsFalse(cat);
        }

        #region Setup
        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);
            categoriesForDb = GetCategoriesForDb();

            context.Categorii.AddRange(categoriesForDb);
            context.SaveChanges();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperMappings>();
            });
            mapper = Mapper.Instance;
        }

        private List<CategoryDb> GetCategoriesForDb()
        {
            return new List<CategoryDb>()
            {
                new CategoryDb(){Id = 0, Code = "Cat1", Description = "Desc1", ForEntity = "Ent1"},
                new CategoryDb(){Id = 0, Code = "Cat2", Description = "Desc2", ForEntity = "Ent2"}
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
