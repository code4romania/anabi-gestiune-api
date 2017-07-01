using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class StorageSpaceConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<StorageSpaceDb>();
            entity.ToTable("StorageSpaces");

            entity.HasKey(k => k.Id);
            entity.Property(p => p.Name).HasMaxLength(200).IsRequired();

            entity.HasIndex(i => i.Name).IsUnique();

            entity.HasOne(a => a.Address)
                .WithOne(s => s.StorageRoom)
                .HasForeignKey<StorageSpaceDb>(k => k.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StorageSpaces_Addresses")
                .IsRequired();

        }
    }
}
