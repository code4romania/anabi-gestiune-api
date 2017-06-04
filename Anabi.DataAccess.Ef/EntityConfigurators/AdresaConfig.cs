using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AdresaConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AdresaDb>();

            entity.ToTable("Adrese");

            entity.HasKey(k => k.Id);

            entity.HasOne(j => j.Judet)
                .WithMany(a => a.Adrese)
                .HasForeignKey(p => p.JudetId)
                .HasConstraintName("FK_Adrese_Judete");

            entity.Property(p => p.Strada).HasMaxLength(100).IsRequired();
            entity.Property(p => p.Oras).HasMaxLength(30);
            entity.Property(p => p.Cladire).HasMaxLength(10);
            entity.Property(p => p.Scara).HasMaxLength(5);
            entity.Property(p => p.Etaj).HasMaxLength(5);
            entity.Property(p => p.NrApartament).HasMaxLength(5);




        }
    }
}
