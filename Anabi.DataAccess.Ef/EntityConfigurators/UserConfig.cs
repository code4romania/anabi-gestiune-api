using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class UserConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<UserDb>();
            entity.ToTable("Users");

            entity.Property(p => p.Password).HasColumnType("varchar(max)").IsRequired();

            entity.Property(p => p.Salt).HasColumnType("varchar(max)").IsRequired();

            entity.HasKey(k => k.Id);
            entity.Property(p => p.UserCode)
                .HasMaxLength(20)
                .IsRequired();
            entity.HasIndex(i => i.UserCode).IsUnique();

            entity.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();
            entity.HasIndex(i => i.Email).IsUnique();

            entity.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.Role)
                .HasMaxLength(5000)
                .IsRequired();

            entity.Property(p => p.IsActive).HasDefaultValue(true).IsRequired();
        }
    }
}
