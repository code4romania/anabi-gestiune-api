using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AddressConfig : BaseEntityConfig<AddressDb>
    {
        public override void Configure(EntityTypeBuilder<AddressDb> builder)
        {
            builder.HasOne(j => j.County)
                .WithMany(a => a.Addresses)
                .HasForeignKey(p => p.CountyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Addresses_Counties")
                .IsRequired();
        }
    }
}
