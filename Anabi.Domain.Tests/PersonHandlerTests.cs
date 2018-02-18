using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Person;
using Anabi.Domain.Person.Commands;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anabi.Domain.Tests
{
    [TestClass]
    public class PersonHandlerTests
    {
        private AnabiContext context;
        private IMapper mapper;

        [TestMethod]
        public async Task AddPerson_ExpectedId()
        {
            Setup();

            var personHandler = new PersonHandler(context, mapper);

            var addPerson = new AddPerson()
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

            var id = await personHandler.Handle(addPerson);

            Assert.AreEqual(1, id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task AddPerson_Existing_ExpectedError()
        {
            Setup();

            var personHandler = new PersonHandler(context, mapper);

            var addPerson = new AddPerson()
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

            var id = await personHandler.Handle(addPerson);


            var addPerson2 = new AddPerson()
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

            var id2 = await personHandler.Handle(addPerson2);

            
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
