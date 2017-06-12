using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class InstitutieConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<InstitutieDb>();
            entity.ToTable("Institutii");

            entity.HasKey(k => k.Id);

            entity.HasOne(c => c.Categorie)
                .WithMany(x => x.Institutii)
                .HasForeignKey(k => k.CategorieId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Institutii_Categorii")
                .IsRequired();

            entity.Property(p => p.Denumire)
                .HasMaxLength(50)
                .IsRequired();

            entity.HasOne(a => a.Adresa)
                .WithMany(i => i.Institutii)
                .HasForeignKey(k => k.AdresaId);

            entity.Property(p => p.CodUtilizatorAdaugare)
               .HasMaxLength(20)
               .IsRequired();

            entity.Property(p => p.CodUtilizatorUltimaModificare)
                .HasMaxLength(20);

            entity.HasOne(u => u.UtilizatorAdaugare)
                .WithMany(nd => nd.InstitutiiAdaugare)
                .HasForeignKey(k => k.CodUtilizatorAdaugare)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Institutii_Utilizator_Adaugare")
                .HasPrincipalKey(k2 => k2.CodUtilizator);

            entity.HasOne(u => u.UtilizatorUltimaModificare)
                .WithMany(nd => nd.InstitutiiModificare)
                .HasForeignKey(k => k.CodUtilizatorUltimaModificare)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Institutii_Utilizator_Modificare")
                .HasPrincipalKey(k2 => k2.CodUtilizator);

            entity.Property(p => p.DataAdaugare)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.DataUltimeiModificari)
                .HasColumnType("Datetime");


        }
    }
}
