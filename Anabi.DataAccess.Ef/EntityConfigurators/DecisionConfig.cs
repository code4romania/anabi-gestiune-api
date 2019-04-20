using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class DecisionConfig : BaseEntityConfig<DecisionDb>
    {
        public override void Configure(EntityTypeBuilder<DecisionDb> builder)
        {
            builder.HasIndex(i => i.Name).HasName("indx_uq_Decision").IsUnique();

            base.Configure(builder);
        }
    }
}
