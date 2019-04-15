using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class PersonConfig : BaseEntityConfig<PersonDb>
    {
        public override void Configure(EntityTypeBuilder<PersonDb> builder)
        {

            builder.HasOne(a => a.Address)
                .WithMany(p => p.Persons)
                .HasForeignKey(k => k.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Persons_Addresses")
                .IsRequired();

            builder.HasIndex(i => i.Identification)
                .IsUnique()
                .HasName("indx_uq_Persons");


            builder.HasOne(p => p.Identifier)
                .WithMany(identifier => identifier.Persons)
                .HasForeignKey(k => k.IdentifierId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Persons_Identifiers");

            base.Configure(builder);
        }
    }
}
