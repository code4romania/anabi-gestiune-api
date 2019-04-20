using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class UserConfig : IEntityTypeConfiguration<UserDb>
    {
        public void Configure(EntityTypeBuilder<UserDb> builder)
        {
            builder.Property(p => p.Password).HasColumnType("varchar(8000)").IsRequired();

            builder.Property(p => p.Salt).HasColumnType("varchar(8000)").IsRequired();

            builder.Property(p => p.UserCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(i => i.UserCode).IsUnique();

            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(i => i.Email).IsUnique();

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Role)
                .HasMaxLength(5000)
                .IsRequired();
        }

    }
}
