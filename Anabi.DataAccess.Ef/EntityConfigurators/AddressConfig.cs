using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AddressConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AddressDb>();

            entity.ToTable("Addresses");

            entity.HasKey(k => k.Id);

            entity.HasOne(j => j.County)
                .WithMany(a => a.Addresses)
                .HasForeignKey(p => p.CountyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Addresses_Counties")
                .IsRequired();

            entity.Property(p => p.Street).HasMaxLength(100).IsRequired();
            entity.Property(p => p.City).HasMaxLength(30);
            entity.Property(p => p.Building).HasMaxLength(10);
            entity.Property(p => p.Stair).HasMaxLength(5);
            entity.Property(p => p.Floor).HasMaxLength(5);
            entity.Property(p => p.FlatNo).HasMaxLength(5);




        }
    }
}
