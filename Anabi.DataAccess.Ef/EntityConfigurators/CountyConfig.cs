using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class CountyConfig : BaseEntityConfig<CountyDb>
    {
        public override void Configure(EntityTypeBuilder<CountyDb> builder)
        {
            builder.HasIndex(i => i.Abreviation).IsUnique();

            base.Configure(builder);
        }
    }
}
