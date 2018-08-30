using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AssetsStorageSpacesConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<AssetStorageSpaceDb>();
            entity.ToTable("AssetsStorageSpaces");

            entity.HasKey(k => k.Id);

            entity.HasOne(s => s.StorageSpace)
                .WithMany(sp => sp.AssetsStorageSpaces)
                .HasForeignKey(k => k.StorageSpaceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AssetsStorageSpaces_StorageSpaces")
                .IsRequired();

            entity.HasOne(s => s.Asset)
                .WithMany(sp => sp.AssetsStorageSpaces)
                .HasForeignKey(k => k.AssetId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AssetsStorageSpaces_Assets")
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

            entity.Property(p => p.EntryDate)
               .HasColumnType("DateTime")
               .IsRequired();

            entity.Property(p => p.ExitDate)
                .HasColumnType("Datetime");

        }
    }
}
