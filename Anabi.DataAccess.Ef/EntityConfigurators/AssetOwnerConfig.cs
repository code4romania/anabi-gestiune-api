using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AssetOwnerConfig : BaseEntityConfig<AssetOwnerDb>
    {

        public override void Configure(EntityTypeBuilder<AssetOwnerDb> builder)
        {
            builder.HasOne(a => a.Asset)
                .WithMany(a => a.Owners)
                .HasForeignKey(k => k.AssetId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_AssetOwner")
                .IsRequired();

            builder.HasOne(a => a.Owner)
                .WithMany(a => a.Owners)
                .HasForeignKey(k => k.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Person_AssetOwner")
                .IsRequired();

            base.Configure(builder);
        }
    }
}