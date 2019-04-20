using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class CategoryConfig : BaseEntityConfig<CategoryDb>
    {
        public override void Configure(EntityTypeBuilder<CategoryDb> builder)
        {
            builder.HasIndex(i => new { i.Code, i.ForEntity })
                .HasName("indx_code_forentity").IsUnique();

            builder.HasOne(p => p.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Categories_Parent");

            base.Configure(builder);
        }
    }
}
