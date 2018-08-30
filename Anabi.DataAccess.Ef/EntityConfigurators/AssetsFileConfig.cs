using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AssetsFileConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AssetsFileDb>();
            entity.ToTable("AssetsFiles");

            entity.HasKey(k => k.Id);

            entity.HasOne(b => b.Asset)
                .WithMany(d => d.FilesForAsset)
                .HasForeignKey(k => k.AssetId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AssetsFiles_Assets")
                .IsRequired();

            entity.HasOne(d => d.File)
                .WithMany(b => b.AssetsFile)
                .HasForeignKey(k => k.FileId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AssetsFiles_Files")
                .IsRequired();

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
