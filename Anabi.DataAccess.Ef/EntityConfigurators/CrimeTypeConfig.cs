using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class CrimeTypeConfig : BaseEntityConfig<CrimeTypeDb>
    {
        public override void Configure(EntityTypeBuilder<CrimeTypeDb> builder)
        {
            builder.HasIndex(i => i.CrimeName).IsUnique();

            base.Configure(builder);
        }
    }
}
