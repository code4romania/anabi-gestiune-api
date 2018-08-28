﻿using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class InstitutionConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<InstitutionDb>();
            entity.ToTable("Institutions");

            entity.HasKey(k => k.Id);

            entity.HasOne(c => c.Category)
                .WithMany(x => x.Institutions)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Institutions_Categories")
                .IsRequired();

            entity.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity.HasOne(a => a.Address)
                .WithMany(i => i.Institutions)
                .HasForeignKey(k => k.AddressId);

            entity.Property(p => p.UserCodeAdd)
               .HasMaxLength(20)
               .IsRequired();

            entity.Property(p => p.UserCodeLastChange)
                .HasMaxLength(20);

            
            entity.Property(p => p.AddedDate)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.LastChangeDate)
                .HasColumnType("Datetime");


        }
    }
}
