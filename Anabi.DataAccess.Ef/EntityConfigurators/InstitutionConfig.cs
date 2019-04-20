using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class InstitutionConfig : BaseEntityConfig<InstitutionDb>
    {
        public override void Configure(EntityTypeBuilder<InstitutionDb> builder)
        {
            builder.Property(p => p.ContactData)
                .HasColumnType("varchar(8000)");

            builder.HasOne(j => j.Category)
                .WithMany(a => a.Institutions)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Institutions_Categories")
                .IsRequired();

            base.Configure(builder);
        }
    }
}
