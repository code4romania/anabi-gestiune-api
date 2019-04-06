using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class CountyConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CountyDb>();

            entity.HasKey(k => k.Id);
            entity.Property(p => p.Abreviation)
                .IsRequired()
                .HasMaxLength(2);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasIndex(i => i.Abreviation).IsUnique();
            
        }
    }
}
