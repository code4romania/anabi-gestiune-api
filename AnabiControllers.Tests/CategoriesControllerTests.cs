using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Abstractions.Repositories;
using System.Collections.Generic;
using System.Linq;
using Anabi.Controllers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnabiControllers.Tests
{
    [TestClass]
    public class CategoriesControllerTests
    {
        [TestMethod]
        public async Task Get_ReturnsListAsync()
        {
            var data = new List<CategoryDb>()
                        {
                            new CategoryDb(){Id = 1, Code = "Code 1", Description = "Code 1 description", ForEntity = "Bunuri"},
                            new CategoryDb(){Id = 2, Code = "Code 2", Description = "Code 2 description", ForEntity = "Bunuri"},
                        }.AsQueryable<CategoryDb>();
            

            var stub = new StubIGenericRepository<CategoryDb>(Etg.SimpleStubs.MockBehavior.Strict)
                .GetAll(() =>
                {
                    return data;
                });

            //new TestAsyncQueryProvider<CategoryDb>(data.Provider).CreateQuery(
            var ctrl = new CategoriesController(stub);
            var results = await ctrl.Get();

            Assert.AreEqual(2, results.Count());
        }
    }
}
