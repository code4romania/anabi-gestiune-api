using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class CategorieConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CategorieDb>();
            entity.ToTable("Categorii");
            entity.HasKey(k => k.Id);
            entity.Property(p => p.Cod).HasMaxLength(50).IsRequired();
            entity.Property(p => p.Descriere).HasMaxLength(2000);
            entity.Property(p => p.PentruEntitate).HasMaxLength(20).IsRequired();

            entity.HasIndex(i => new { i.Cod, i.PentruEntitate}).HasName("indx_cod_pentruentitate").IsUnique();

            entity.HasOne(p => p.Parinte)
                .WithMany(p => p.Copii)
                .HasForeignKey(p => p.ParinteId)
                .HasConstraintName("FK_Categorii_Parinte");
        }
    }
}
