using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class InstitutionConfig : BaseEntityConfig<InstitutionDb>
    {
        public override void Configure(EntityTypeBuilder<InstitutionDb> builder)
        {
            builder.Property(p => p.BusinessId)
                .HasColumnType("int");

            builder.Property(p => p.ContactData)
                .HasColumnType("varchar(8000)");

            base.Configure(builder);
        }
    }
}
