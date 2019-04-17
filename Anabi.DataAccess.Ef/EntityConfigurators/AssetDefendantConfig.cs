using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AssetDefendantConfig : BaseEntityConfig<AssetDefendantDb>
    {

        public override void Configure(EntityTypeBuilder<AssetDefendantDb> builder)
        {
            builder.HasOne(a => a.Asset)
                .WithMany(a => a.Defendants)
                .HasForeignKey(k => k.AssetId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_AssetDefendant")
                .IsRequired();

            builder.HasOne(a => a.Defendant)
                .WithMany(a => a.Defendants)
                .HasForeignKey(k => k.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Person_AssetDefendant")
                .IsRequired();

            base.Configure(builder);
        }
    }
}
