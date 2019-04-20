using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class StageConfig : BaseEntityConfig<StageDb>
    {
        public override void Configure(EntityTypeBuilder<StageDb> builder)
        {
            builder.HasIndex(i => i.Name).HasName("indx_uq_stagename").IsUnique();

            base.Configure(builder);
        }
    }
}
