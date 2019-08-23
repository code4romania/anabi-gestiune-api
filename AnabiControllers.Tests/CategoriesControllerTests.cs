using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anabi.DataAccess.Ef.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Anabi.Domain.Category;
using Anabi.Domain.Category.Commands;
using Anabi.Features.Category;
using Anabi.Features.Category.Models;
using System;
using System.Security.Principal;
using Anabi.Domain;
using System.Threading;
using Anabi.Tests.Common;

namespace AnabiControllers.Tests
{
    [TestClass]
    public class CategoriesControllerTests
    {
        private AnabiContext context;
        private List<CategoryDb> categoriesForDb;
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
        }

        [TestMethod]
        public async Task Get_ReturnsListAsync()
        {

            var queryHandler = new CategoryQueryHandler(BasicNeeds);

            var query = new GetCategory() { Id = null };

            var actual = await queryHandler.Handle(query, CancellationToken.None);

            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public async Task Post()
        {

            var queryHandler = new CategoryHandler(BasicNeeds);
            var query = new AddCategory()
            {
                Code = "Code 3",
                Description = "Desc Code 3",
                ForEntity = "Test ent 3",
                
                ParentId = null
            };

            await queryHandler.Handle(query, CancellationToken.None);

            var cat = await context.Categories.FirstAsync<CategoryDb>(p => p.Code == "Code 3");

            Assert.IsNotNull(cat);

        }

        [TestMethod]
        public async Task Put()
        {
            var queryHandler = new CategoryHandler(BasicNeeds);

            var categ = context.Categories.First();
            var query = new EditCategory()
            {
                Code = "Code 3",
                Description = "Desc Code 3",
                ForEntity = "Test ent 3",
                Id = categ.Id,
                ParentId = null
            };

            await queryHandler.Handle(query, CancellationToken.None);

            var cat = await context.Categories.FirstAsync<CategoryDb>(p => p.Code == "Code 3");

            Assert.IsNotNull(cat);

        }

        [TestMethod]
        public async Task Delete()
        {
            var handler = new CategoryHandler(BasicNeeds);

            var categ = context.Categories.First();
            var query = new DeleteCategory
            {
                Id = categ.Id,
            };

            await handler.Handle(query, CancellationToken.None);

            var cat = await context.Categories.AnyAsync<CategoryDb>(p => p.Id == categ.Id);

            Assert.IsFalse(cat);
        }

        [TestMethod]
        public void InitializeDB()
        {
            DbInitializer.InitializeFullDb(context);
            Assert.IsTrue(context.Categories.Count() > 0);
        }

        #region Setup
        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);
            categoriesForDb = GetCategoriesForDb();

            context.Categories.AddRange(categoriesForDb);
            context.SaveChanges();

            mapper = MapperCreator.CreateAutomapper();
            principal = PrincipalCreator.TestAuthentificatedPrincipal();
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
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .Options;
        } 
        #endregion
    }
}
