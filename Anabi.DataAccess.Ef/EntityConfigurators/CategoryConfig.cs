using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class CategoryConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CategoryDb>();
            entity.ToTable("Categories");
            entity.HasKey(k => k.Id);
            entity.Property(p => p.Code).HasMaxLength(50).IsRequired();
            entity.Property(p => p.Description).HasMaxLength(2000);
            entity.Property(p => p.ForEntity).HasMaxLength(20).IsRequired();

            entity.HasIndex(i => new { i.Code, i.ForEntity}).HasName("indx_code_forentity").IsUnique();

            entity.HasOne(p => p.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Categories_Parent");
        }
    }
}
