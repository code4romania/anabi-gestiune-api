using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class BunuriSpatiiStocareConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<BunSpatiuStocareDb>();
            entity.ToTable("BunuriSpatiiStocare");

            entity.HasKey(k => k.Id);

            entity.HasOne(s => s.SpatiuStocare)
                .WithMany(sp => sp.BunuriSpatiiStocare)
                .HasForeignKey(k => k.SpatiuStocareId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_BunuriSpatiiStocare_SpatiiStocare")
                .IsRequired();

            entity.HasOne(s => s.Bun)
                .WithMany(sp => sp.BunuriSpatiiStocare)
                .HasForeignKey(k => k.BunId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_BunuriSpatiiStocare_Bunuri")
                .IsRequired();


            entity.Property(p => p.CodUtilizatorAdaugare)
             .HasMaxLength(20)
             .IsRequired();

            entity.Property(p => p.CodUtilizatorUltimaModificare)
                .HasMaxLength(20);

            entity.HasOne(u => u.UtilizatorAdaugare)
                .WithMany(nd => nd.BunuriSpatiiStocareAdaugare)
                .HasForeignKey(k => k.CodUtilizatorAdaugare)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_BunuriSpatiiStocare_Utilizator_Adaugare")
                .HasPrincipalKey(k2 => k2.CodUtilizator);

            entity.HasOne(u => u.UtilizatorUltimaModificare)
                .WithMany(nd => nd.BunuriSpatiiStocareModificare)
                .HasForeignKey(k => k.CodUtilizatorUltimaModificare)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_BunuriSpatiiStocare_Utilizator_Modificare")
                .HasPrincipalKey(k2 => k2.CodUtilizator);


            entity.Property(p => p.DataAdaugare)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.DataUltimeiModificari)
                .HasColumnType("Datetime");

            entity.Property(p => p.DataIntrare)
               .HasColumnType("DateTime")
               .IsRequired();

            entity.Property(p => p.DataIesire)
                .HasColumnType("Datetime");

        }
    }
}
