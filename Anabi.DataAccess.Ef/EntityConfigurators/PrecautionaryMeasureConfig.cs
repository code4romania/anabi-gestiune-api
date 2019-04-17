using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class PrecautionaryMeasureConfig : BaseEntityConfig<PrecautionaryMeasureDb>
    {
        public override void Configure(EntityTypeBuilder<PrecautionaryMeasureDb> builder)
        {
            base.Configure(builder);
        }
    }
}
