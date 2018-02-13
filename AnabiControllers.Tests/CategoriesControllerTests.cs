using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anabi.DataAccess.Ef.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Anabi;
using Anabi.Domain.Category;
using Anabi.Domain.Category.Commands;
using Anabi.Features.Category;
using Anabi.Features.Category.Models;

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

            var query = new GetCategory() { Id = null };

            var actual = await queryHandler.Handle(query);

            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public async Task Post()
        {

            Setup();

            var queryHandler = new CategoryHandler(context, mapper);
            var query = new AddCategory()
            {
                Code = "Code 3",
                Description = "Desc Code 3",
                ForEntity = "Test ent 3",
                
                ParentId = null
            };

            await queryHandler.Handle(query);

            var cat = await context.Categories.FirstAsync<CategoryDb>(p => p.Code == "Code 3");

            Assert.IsNotNull(cat);

        }

        [TestMethod]
        public async Task Put()
        {
            Setup();

            var queryHandler = new CategoryHandler(context, mapper);

            var query = new EditCategory()
            {
                Code = "Code 3",
                Description = "Desc Code 3",
                ForEntity = "Test ent 3",
                Id = 1,
                ParentId = null
            };

            await queryHandler.Handle(query);

            var cat = await context.Categories.FirstAsync<CategoryDb>(p => p.Code == "Code 3");

            Assert.IsNotNull(cat);

        }

        [TestMethod]
        public async Task Delete()
        {
            Setup();
            var handler = new CategoryHandler(context, mapper);

            var query = new DeleteCategory
            {
                Id = 1
            };

            await handler.Handle(query);

            var cat = await context.Categories.AnyAsync<CategoryDb>(p => p.Id == 1);

            Assert.IsFalse(cat);
        }

        [TestMethod]
        public void InitializeDB()
        {
            Setup();
            DbInitializer.Initialize(context);
            Assert.AreEqual(2, context.StorageSpaces.Count());
        }

        #region Setup
        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);
            categoriesForDb = GetCategoriesForDb();

            context.Categories.AddRange(categoriesForDb);
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
