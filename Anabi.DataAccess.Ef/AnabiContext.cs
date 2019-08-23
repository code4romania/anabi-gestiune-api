using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using System.Reflection;

namespace Anabi.DataAccess.Ef
{
    public class AnabiContext : DbContext
    {
        
        public AnabiContext(DbContextOptions<AnabiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<AddressDb> Addresses { get; set; }
        public DbSet<AssetDb> Assets { get; set; }
        
        public DbSet<CategoryDb> Categories { get; set; }
        public DbSet<DecisionDb> Decisions { get; set; }
        
        public DbSet<StageDb> Stages { get; set; }
        public DbSet<HistoricalStageDb> HistoricalStages { get; set; }
        
        public DbSet<InstitutionDb> Institutions { get; set; }
        public DbSet<CountyDb> Counties { get; set; }
        
        public DbSet<PersonDb> Persons { get; set; }
        public DbSet<StorageSpaceDb> StorageSpaces { get; set; }
        public DbSet<UserDb> Users { get; set; }

        public DbSet<AssetStorageSpaceDb> AssetStorageSpaces { get; set; }
        public DbSet<RecoveryBeneficiaryDb> RecoveryBeneficiaries { get; set; }

        public DbSet<IdentifierDb> Identifiers { get; set; }

        public DbSet<AssetDefendantDb> AssetDefendants { get; set; }

        public DbSet<AssetOwnerDb> AssetOwners { get; set; }

        public DbSet<CrimeTypeDb> CrimeTypes { get; set; }

        public DbSet<PrecautionaryMeasureDb> PrecautionaryMeasures { get; set; }
        
    }
    
}
