using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class FileConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<FileDb>();
            entity.ToTable("Files");

            entity.HasKey(k => k.Id);


            

            entity.Property(x => x.InitialFileNumber)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.CurrentFileNumber)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(p => p.DamageAmount)
                .IsRequired();
            entity.Property(p => p.DamageCurrency)
                .IsRequired();
            entity.Property(p => p.LegalClassification)
                .IsRequired();
            entity.Property(p => p.CriminalField)
                .IsRequired();

            entity.Property(p => p.UserCodeAdd)
               .HasMaxLength(20)
               .IsRequired();

            entity.Property(p => p.UserCodeLastChange)
                .HasMaxLength(20);


            entity.HasOne(u => u.UserAdd)
                .WithMany(nd => nd.FilesAdded)
                .HasForeignKey(k => k.UserCodeAdd)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Files_User_Add")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.UserLastChange)
                .WithMany(nd => nd.FilesChanged)
                .HasForeignKey(k => k.UserCodeLastChange)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Files_User_Change")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.Property(p => p.AddedDate)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.LastChangeDate)
                .HasColumnType("Datetime");

        }
    }
}
