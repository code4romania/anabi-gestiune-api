using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class DefendantsFileConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<DefendantsFileDb>();
            entity.ToTable("DefendantsFiles");
            entity.HasKey(k => k.Id);

            entity.HasIndex(i => new { i.PersonId, i.FileId })
                .IsUnique()
                .HasName("indx_uq_DefendantsFile");

            entity.HasOne(p => p.Defendant)
                .WithMany(ids => ids.Files)
                .HasForeignKey(k => k.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DefendantsFile_Persoane")
                .IsRequired();

            entity.HasOne(d => d.File)
                .WithMany(i => i.Defendants)
                .HasForeignKey(k => k.FileId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DefendantsFile_Dosare")
                .IsRequired();

            entity.Property(p => p.UserCodeAdd)
               .HasMaxLength(20)
               .IsRequired();

            entity.Property(p => p.UserCodeLastChange)
                .HasMaxLength(20);


            entity.HasOne(u => u.UserAdd)
                .WithMany(nd => nd.DefendantFilesAdded)
                .HasForeignKey(k => k.UserCodeAdd)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DefendantsFile_User_Add")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.UserLastChange)
                .WithMany(nd => nd.DefendantFilesChanged)
                .HasForeignKey(k => k.UserCodeLastChange)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DefendantsFile_User_Change")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.Property(p => p.AddedDate)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.LastChangeDate)
                .HasColumnType("Datetime");
        }
    }
}
