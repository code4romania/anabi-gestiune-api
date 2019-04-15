using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class StorageSpaceConfig : BaseEntityConfig<StorageSpaceDb>
    {
        public override void Configure(EntityTypeBuilder<StorageSpaceDb> builder)
        {
            builder.HasIndex(i => i.Name)
                .HasName("uq_StorageSpaceName")
                .IsUnique();

            builder.HasOne(a => a.Address)
                .WithOne(s => s.StorageRoom)
                .HasForeignKey<StorageSpaceDb>(k => k.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StorageSpaces_Addresses")
                .IsRequired();

            base.Configure(builder);
        }
    }
}
