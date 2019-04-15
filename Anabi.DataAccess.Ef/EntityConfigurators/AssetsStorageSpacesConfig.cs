using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AssetsStorageSpacesConfig : BaseEntityConfig<AssetStorageSpaceDb>
    {
        public override void Configure(EntityTypeBuilder<AssetStorageSpaceDb> builder)
        {
            builder.HasOne(s => s.StorageSpace)
                .WithMany(sp => sp.AssetsStorageSpaces)
                .HasForeignKey(k => k.StorageSpaceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AssetsStorageSpaces_StorageSpaces")
                .IsRequired();

            builder.HasOne(s => s.Asset)
                .WithMany(sp => sp.AssetsStorageSpaces)
                .HasForeignKey(k => k.AssetId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AssetsStorageSpaces_Assets")
                .IsRequired();

            base.Configure(builder);
        }

        public void SetupEntity(ModelBuilder modelBuilder)
        {
            //entity.Property(p => p.EntryDate)
            //   .HasColumnType("DateTime")
            //   .IsRequired();

            //entity.Property(p => p.ExitDate)
            //    .HasColumnType("Datetime");

        }
    }
}
