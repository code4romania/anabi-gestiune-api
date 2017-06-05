using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

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

            entity.Property(p => p.DataAdaugare)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.DataUltimeiModificari)
                .HasColumnType("Datetime");


        }
    }
}
