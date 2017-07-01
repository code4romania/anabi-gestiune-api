using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class StageConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<StageDb>();
            entity.ToTable("Stages");
            entity.HasKey(k => k.Id);
            entity.Property(p => p.Name).HasMaxLength(50).IsRequired();
            entity.HasIndex(i => i.Name).HasName("indx_uq_stagename").IsUnique();

            entity.Property(p => p.IsFinal).IsRequired();



        }
    }
}
