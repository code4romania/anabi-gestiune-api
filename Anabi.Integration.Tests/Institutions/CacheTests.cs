﻿using Anabi.DataAccess.Ef.DbModels;
using Anabi.Features.Institution.Models;
using AutoFixture;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Institutions
{
    public class CacheTests : ApiTests
    {
        private Fixture _fixture;

        public CacheTests(AnabiApplicationFactory<Startup> factory) : base(factory)
        {
            Context = new AnabiDbContextBuilder()
                .CreateInMemorySqliteDbContext()
                .Build();

            Client = factory.CreateClient();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetInstitutions_ReturnsFromCache()
        {
            //Clean context of existing institutions
            var institutionsToRemove = Context.Institutions.ToList();
            Context.Institutions.RemoveRange(institutionsToRemove);
            Context.SaveChanges();

            var nrOfInstitutions = 3;
            AddInstitutionsToContext(nrOfInstitutions);
            var viewModels = await GetInstitutionsViaAPI();

            Assert.Equal(nrOfInstitutions, viewModels.Count);

            AddInstitutionsToContext(2);
            var viewModels2 = await GetInstitutionsViaAPI();

            Assert.Equal(nrOfInstitutions, viewModels2.Count);
        }

        [Fact]
        public async Task GetInstitution_ReturnFromCache()
        {
            var originalName = "Institutia A";
            var model = CreateInstitution(originalName);
            Context.Institutions.Add(model);
            Context.SaveChanges();

            //calls the API and so saves the entry in the cache
            var viewModel = await GetInstitutionViaAPI(model.Id);

            model.Name = "Institutia B";
            Context.SaveChanges();

            viewModel = await GetInstitutionViaAPI(model.Id);
            Assert.Equal(originalName, viewModel.Name);
        }

        [Fact]
        public async Task GetInstitution_ReturnFromCacheBasedOnInstitutionId()
        {
            var model = CreateInstitution("aaa");
            Context.Institutions.Add(model);
            Context.SaveChanges();

            //calls the API and so saves the entry in the cache
            var viewModel = await GetInstitutionViaAPI(model.Id);


            var model2 = CreateInstitution("bbbb");
            Context.Institutions.Add(model2);
            Context.SaveChanges();

            viewModel = await GetInstitutionViaAPI(model2.Id);
            Assert.Equal("bbbb", viewModel.Name);
        }

        private InstitutionDb CreateInstitution(string name)
        {
            return _fixture.Build<InstitutionDb>()
                .With(p => p.Name, name)
                .Without(p => p.HistoricalStages)
                .Create();
        }

        private async Task<List<Institution>> GetInstitutionsViaAPI()
        {
            var response = await Client.GetAsync($"api/institutions");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var viewModels = JsonConvert.DeserializeObject<List<Institution>>(data);
            return viewModels;
        }
        private async Task<Institution> GetInstitutionViaAPI(int id)
        {
            var response = await Client.GetAsync($"api/institutions/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var viewModels = JsonConvert.DeserializeObject<List<Institution>>(data);
            return viewModels.Single();
        }

        private void AddInstitutionsToContext(int nrOfInstitutions)
        {
            var models = _fixture
                .Build<InstitutionDb>()
                .Without(p => p.HistoricalStages)
                .Without(p => p.Id)
                .CreateMany(nrOfInstitutions);

            Context.Institutions.AddRange(models);
            Context.SaveChanges();
        }
    }
}
