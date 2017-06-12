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

            (new UtilizatorConfig()).SetupEntity(modelBuilder);

            (new JudetConfig()).SetupEntity(modelBuilder);
            (new AdresaConfig()).SetupEntity(modelBuilder);
            (new CategorieConfig()).SetupEntity(modelBuilder);

            (new EtapaConfig()).SetupEntity(modelBuilder);
            (new DecizieConfig()).SetupEntity(modelBuilder);
            (new EtapePentruDecizieConfig()).SetupEntity(modelBuilder);
            (new InstitutieConfig()).SetupEntity(modelBuilder);
            (new PersoanaConfig()).SetupEntity(modelBuilder);

            (new NumarDosarConfig()).SetupEntity(modelBuilder);
            (new DosarConfig()).SetupEntity(modelBuilder);
            (new InculpatiDosarConfig()).SetupEntity(modelBuilder);

            (new BunConfig()).SetupEntity(modelBuilder);
            (new EtapaIstoricaConfig()).SetupEntity(modelBuilder);

            (new BunuriDosarConfig()).SetupEntity(modelBuilder);

            (new SpatiuStocareConfig()).SetupEntity(modelBuilder);

            (new BunuriSpatiiStocareConfig()).SetupEntity(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AdresaDb> Adrese { get; set; }
        public DbSet<BunDb> Bunuri { get; set; }
        public DbSet<BunuriDosarDb> BunuriDosare { get; set; }
        public DbSet<CategorieDb> Categorii { get; set; }
        public DbSet<DecizieDb> Decizii { get; set; }
        public DbSet<DosarDb> Dosare { get; set; }
        public DbSet<EtapaDb> Etape { get; set; }
        public DbSet<EtapaIstoricaDb> EtapeIstorice { get; set; }
        public DbSet<EtapePentruDecizieDb> EtapePentruDecizii { get; set; }
        public DbSet<InculpatiDosarDb> InculpatiDosar { get; set; }
        public DbSet<InstitutieDb> Institutii { get; set; }
        public DbSet<JudetDb> Judete { get; set; }
        public DbSet<NumarDosarDb> NumereDosare { get; set; }
        public DbSet<PersoanaDb> Persoane { get; set; }
        public DbSet<SpatiuStocareDb> SpatiiStocare { get; set; }
        public DbSet<UtilizatorDb> Utilizatori { get; set; }

        public DbSet<BunSpatiuStocareDb> BunuriSpatiiStocare { get; set; }

    }
}
