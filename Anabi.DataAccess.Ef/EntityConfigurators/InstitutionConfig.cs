using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class InstitutionConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<InstitutionDb>();
            entity.ToTable("Institutions");

            entity.HasKey(k => k.Id);

            entity.HasOne(c => c.Category)
                .WithMany(x => x.Institutions)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Institutions_Categories")
                .IsRequired();

            entity.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity.HasOne(a => a.Address)
                .WithMany(i => i.Institutions)
                .HasForeignKey(k => k.AddressId);

            entity.Property(p => p.UserCodeAdd)
               .HasMaxLength(20)
               .IsRequired();

            entity.Property(p => p.UserCodeLastChange)
                .HasMaxLength(20);

            entity.HasOne(u => u.UserAdd)
                .WithMany(nd => nd.InstitutionsAdded)
                .HasForeignKey(k => k.UserCodeAdd)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Institutions_User_Add")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.UserLastChange)
                .WithMany(nd => nd.InstitutionsChanged)
                .HasForeignKey(k => k.UserCodeLastChange)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Institutions_User_Change")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.Property(p => p.AddedDate)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.LastChangeDate)
                .HasColumnType("Datetime");


        }
    }
}
