using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class SpatiuStocareConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SpatiuStocareDb>();
            entity.ToTable("SpatiiStocare");

            entity.HasKey(k => k.Id);
            entity.Property(p => p.Denumire).HasMaxLength(200).IsRequired();

            entity.HasIndex(i => i.Denumire).IsUnique();

            entity.HasOne(a => a.Adresa)
                .WithOne(s => s.SpatiuStocare)
                .HasForeignKey<SpatiuStocareDb>(k => k.AdresaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_SpatiiStocare_Adrese")
                .IsRequired();

        }
    }
}
