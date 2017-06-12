using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class UtilizatorConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<UtilizatorDb>();
            entity.ToTable("Utilizatori");

            entity.HasKey(k => k.Id);
            entity.Property(p => p.CodUtilizator)
                .HasMaxLength(20)
                .IsRequired();
            entity.HasIndex(i => i.CodUtilizator).IsUnique();

            entity.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();
            entity.HasIndex(i => i.Email).IsUnique();

            entity.Property(p => p.Nume)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.Rol)
                .HasMaxLength(5000)
                .IsRequired();

            entity.Property(p => p.EsteActiv).HasDefaultValue(true).IsRequired();
        }
    }
}
