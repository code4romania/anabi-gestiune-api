using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Person;
using Anabi.Domain.Person.Commands;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Tests
{
    [TestClass]
    public class PersonHandlerTests
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
        public async Task AddPerson_ExpectedId()
        {

            var personHandler = new PersonHandler(BasicNeeds);

            var addPerson = new AddDefendant()
            {
                Birthdate = new DateTime(1982, 10, 25),
                FirstName = "Alex",
                Identification = "182084115982",
                IdentifierId = 1,
                IdNumber = "123123",
                IdSerie = "TT",
                IsPerson = true,
                Name = "Albu",
                Nationality = "Romana"

            };

            var viewmodel = await personHandler.Handle(addPerson, CancellationToken.None);

            var defendant = context.Persons.First(x => x.Identification == "182084115982");

            Assert.AreEqual(defendant.Id, viewmodel.Id);
        }

       

        #region Setup
        private void Setup()
        {
            DbContextOptions<AnabiContext> options = GetContextOptions();

            context = new AnabiContext(options);

            AddAdminUser();
            AddIdentifiers();

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

        private void AddIdentifiers()
        {
            var identifiers = new List<IdentifierDb>()
            {
                new IdentifierDb(){IsForPerson = true, AddedDate = DateTime.Now, IdentifierType = "CNP", UserCodeAdd = "admin" },
                new IdentifierDb(){IsForPerson = true, AddedDate = DateTime.Now, IdentifierType = "Pasaport", UserCodeAdd = "admin" },
                new IdentifierDb(){IsForPerson = false, AddedDate = DateTime.Now, IdentifierType = "CUI", UserCodeAdd = "admin" }
            };

            this.context.Identifiers.AddRange(identifiers);
            this.context.SaveChanges();
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
