using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Ef.EntityConfigurators;
using System.Linq;

namespace Anabi.DataAccess.Ef
{
    public class AnabiContext : DbContext
    {
        
        public AnabiContext(DbContextOptions<AnabiContext> options) : base(options)
        {
        }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            (new UserConfig()).SetupEntity(modelBuilder);

            (new CountyConfig()).SetupEntity(modelBuilder);
            (new AddressConfig()).SetupEntity(modelBuilder);
            (new CategoryConfig()).SetupEntity(modelBuilder);

            (new StageConfig()).SetupEntity(modelBuilder);
            (new DecisionConfig()).SetupEntity(modelBuilder);
            (new StagesForDecisionConfig()).SetupEntity(modelBuilder);
            (new InstitutionConfig()).SetupEntity(modelBuilder);
            (new PersonConfig()).SetupEntity(modelBuilder);

            (new FileNumberConfig()).SetupEntity(modelBuilder);
            (new FileConfig()).SetupEntity(modelBuilder);
            (new DefendantsFileConfig()).SetupEntity(modelBuilder);

            (new AssetConfig()).SetupEntity(modelBuilder);
            (new HistoricalStageConfig()).SetupEntity(modelBuilder);

            (new AssetsFileConfig()).SetupEntity(modelBuilder);

            (new StorageSpaceConfig()).SetupEntity(modelBuilder);

            (new AssetsStorageSpacesConfig()).SetupEntity(modelBuilder);
            (new RecoveryBeneficiaryConfig()).SetupEntity(modelBuilder);

            (new IdentifierConfig()).SetupEntity(modelBuilder);
            (new AssetDefendantConfig()).SetupEntity(modelBuilder);

            

            base.OnModelCreating(modelBuilder);
        } */

        public DbSet<AddressDb> Addresses { get; set; }
        public DbSet<AssetDb> Assets { get; set; }
        
        public DbSet<CategoryDb> Categories { get; set; }
        public DbSet<DecisionDb> Decisions { get; set; }
        
        public DbSet<StageDb> Stages { get; set; }
        public DbSet<HistoricalStageDb> HistoricalStages { get; set; }
        public DbSet<StagesForDecisionDb> StagesForDecisions { get; set; }
        
        public DbSet<InstitutionDb> Institutions { get; set; }
        public DbSet<CountyDb> Counties { get; set; }
        
        public DbSet<PersonDb> Persons { get; set; }
        public DbSet<StorageSpaceDb> StorageSpaces { get; set; }
        public DbSet<UserDb> Users { get; set; }

        public DbSet<AssetStorageSpaceDb> AssetStorageSpaces { get; set; }
        public DbSet<RecoveryBeneficiaryDb> RecoveryBeneficiaries { get; set; }

        public DbSet<IdentifierDb> Identifiers { get; set; }

        public DbSet<AssetDefendantDb> AssetDefendants { get; set; }

        public DbSet<AssetsFileDb> BunuriDosare { get; set; }
        public DbSet<FileDb> Dosare { get; set; }
        public DbSet<DefendantsFileDb> InculpatiDosar { get; set; }

        public DbSet<FileNumberDb> NumereDosare { get; set; }

        public DbSet<CrimeTypeDb> CrimeTypes { get; set; }

        public DbSet<PrecautionaryMeasureDb> PrecautionaryMeasures { get; set; }
        
    }
    
}
