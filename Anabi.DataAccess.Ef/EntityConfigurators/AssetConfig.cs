using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AssetConfig : BaseEntityConfig<AssetDb>
    {

        public override void Configure(EntityTypeBuilder<AssetDb> builder)
        {
            builder.HasOne(a => a.Address)
                .WithMany(b => b.Assets)
                .HasForeignKey(k => k.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_Addresses");

            builder.HasOne(k => k.Category)
                .WithMany(b => b.Assets)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_Categories")
                .IsRequired();

            builder.HasOne(d => d.CurrentDecision)
                .WithMany(b => b.Assets)
                .HasForeignKey(k => k.DecisionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_Decisions");

            base.Configure(builder);
        }
    }
}
