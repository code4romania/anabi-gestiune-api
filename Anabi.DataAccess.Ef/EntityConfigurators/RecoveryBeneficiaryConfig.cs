using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class RecoveryBeneficiaryConfig : BaseEntityConfig<RecoveryBeneficiaryDb>
    {
        public override void Configure(EntityTypeBuilder<RecoveryBeneficiaryDb> builder)
        {
            builder.HasIndex(p => p.Name)
                .HasName("uq_RecoveryBeneficiaryName")
                .IsUnique();

            base.Configure(builder);
        }
    }
}