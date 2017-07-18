using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Ef.EntityConfigurators;

namespace Anabi.DataAccess.Ef
{
    public class AnabiContext : DbContext
    {
        
        public AnabiContext(DbContextOptions<AnabiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
            base.OnModelCreating(modelBuilder);
            (new RecoveryBeneficiaryConfig()).SetupEntity(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AddressDb> Adrese { get; set; }
        public DbSet<AssetDb> Bunuri { get; set; }
        public DbSet<AssetsFileDb> BunuriDosare { get; set; }
        public DbSet<CategoryDb> Categorii { get; set; }
        public DbSet<DecisionDb> Decizii { get; set; }
        public DbSet<FileDb> Dosare { get; set; }
        public DbSet<StageDb> Etape { get; set; }
        public DbSet<HistoricalStageDb> EtapeIstorice { get; set; }
        public DbSet<StagesForDecisionDb> EtapePentruDecizii { get; set; }
        public DbSet<DefendantsFileDb> InculpatiDosar { get; set; }
        public DbSet<InstitutionDb> Institutii { get; set; }
        public DbSet<CountyDb> Judete { get; set; }
        public DbSet<FileNumberDb> NumereDosare { get; set; }
        public DbSet<PersonDb> Persoane { get; set; }
        public DbSet<StorageSpaceDb> SpatiiStocare { get; set; }
        public DbSet<UserDb> Utilizatori { get; set; }

        public DbSet<AssetStorageSpaceDb> BunuriSpatiiStocare { get; set; }
        public DbSet<RecoveryBeneficiaryDb> BeneficiariValorificari { get; set; }

    }
}
