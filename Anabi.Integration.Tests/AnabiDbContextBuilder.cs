using Anabi.DataAccess.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using TestSupport.EfHelpers;

namespace Anabi.Integration.Tests
{
    public class AnabiDbContextBuilder
    {
        private AnabiContext context;

        public AnabiDbContextBuilder CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AnabiContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new AnabiContext(options);
            
            return this;
        }

        public AnabiDbContextBuilder CreateInMemorySqliteDbContext()
        {
            context = new AnabiContext(SqliteInMemory.CreateOptions<AnabiContext>());
            context.Database.EnsureCreated();
            return this;
        }

        public AnabiDbContextBuilder WithAssetCategories()
        {
            DbInitializer.AddCategories(context);

            return this;
        }

        public AnabiDbContextBuilder WithCrimeTypes()
        {
            DbInitializer.AddCrimeTypes(context);
            return this;
        }

        public AnabiDbContextBuilder WithUsers()
        {
            DbInitializer.AddUsers(context);
            return this;
        }

        public AnabiDbContextBuilder WithDecisions()
        {
            DbInitializer.AddDecisions(context);
            return this;
        }

        public AnabiDbContextBuilder WithStages()
        {
            DbInitializer.AddStages(context);
            return this;
        }

        public AnabiDbContextBuilder WithCounties()
        {
            DbInitializer.AddCounties(context);
            return this;
        }

        public AnabiDbContextBuilder WithRecoveryBeneficiaries()
        {
            DbInitializer.AddRecoveryBeneficiaries(context);
            return this;
        }

        public AnabiDbContextBuilder WithAllDictionaries()
        {
            DbInitializer.InitializeFullDb(context);
            return this;
        }

        public AnabiContext Build()
        {
            return context;
        }
    }
}
