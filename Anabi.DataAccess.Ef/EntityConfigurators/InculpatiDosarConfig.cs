using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class InculpatiDosarConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<InculpatiDosarDb>();
            entity.ToTable("InculpatiDosare");
            entity.HasKey(k => k.Id);

            entity.HasIndex(i => new { i.PersoanaId, i.DosarId })
                .IsUnique()
                .HasName("indx_uq_InculpatiDosar");

            entity.HasOne(p => p.Inculpat)
                .WithMany(ids => ids.Dosare)
                .HasForeignKey(k => k.PersoanaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_InculpatiDosar_Persoane")
                .IsRequired();

            entity.HasOne(d => d.Dosar)
                .WithMany(i => i.Inculpati)
                .HasForeignKey(k => k.DosarId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_InculpatiDosar_Dosare")
                .IsRequired();

            entity.Property(p => p.CodUtilizatorAdaugare)
               .HasMaxLength(20)
               .IsRequired();

            entity.Property(p => p.CodUtilizatorUltimaModificare)
                .HasMaxLength(20);


            entity.HasOne(u => u.UtilizatorAdaugare)
                .WithMany(nd => nd.InculpatiDosareAdaugare)
                .HasForeignKey(k => k.CodUtilizatorAdaugare)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_InculpatiDosare_Utilizator_Adaugare")
                .HasPrincipalKey(k2 => k2.CodUtilizator);

            entity.HasOne(u => u.UtilizatorUltimaModificare)
                .WithMany(nd => nd.InculpatiDosareModificare)
                .HasForeignKey(k => k.CodUtilizatorUltimaModificare)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_InculpatiDosare_Utilizator_Modificare")
                .HasPrincipalKey(k2 => k2.CodUtilizator);

            entity.Property(p => p.DataAdaugare)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.DataUltimeiModificari)
                .HasColumnType("Datetime");
        }
    }
}
