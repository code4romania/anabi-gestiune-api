using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class BunConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<BunDb>();
            entity.ToTable("Bunuri");

            entity.HasKey(k => k.Id);
            entity.HasOne(a => a.Adresa)
                .WithMany(b => b.Bunuri)
                .HasForeignKey(k => k.AdresaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Bunuri_Adrese")
                .IsRequired();

            entity.HasOne(k => k.Categorie)
                .WithMany(b => b.Bunuri)
                .HasForeignKey(k => k.CategorieId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Bunuri_Categorii")
                .IsRequired();

            entity.HasOne(k => k.EtapaCurenta)
                .WithMany(b => b.Bunuri)
                .HasForeignKey(k => k.EtapaCurentaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Bunuri_Etape")
                .IsRequired();

            entity.HasOne(d => d.DeciziaCurenta)
                .WithMany(b => b.Bunuri)
                .HasForeignKey(k => k.DecizieId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Bunuri_Decizii")
                .IsRequired();

            entity.Property(b => b.EsteSters)
                .IsRequired();

            entity.Property(p => p.CodUtilizatorAdaugare)
              .HasMaxLength(20)
              .IsRequired();

            entity.Property(p => p.CodUtilizatorUltimaModificare)
                .HasMaxLength(20);

            entity.Property(p => p.DataAdaugare)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.DataUltimeiModificari)
                .HasColumnType("Datetime");







        }
    }
}
