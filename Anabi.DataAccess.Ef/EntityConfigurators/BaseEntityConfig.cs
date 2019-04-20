using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public abstract class BaseEntityConfig<TBase> : IEntityTypeConfiguration<TBase> 
        where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Property(p => p.AddedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
