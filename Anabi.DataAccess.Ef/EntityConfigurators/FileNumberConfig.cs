using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class FileNumberConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<FileNumberDb>();
            entity.ToTable("FileNumbers");

            entity.HasKey(k => k.Id);

            entity.Property(p => p.FileNumber)
                .HasMaxLength(50)
                .IsRequired();

           
            entity.HasOne(i => i.Institution)
                .WithMany(d => d.FileNumbers)
                .HasForeignKey(k => k.InstitutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_NumereDosare_Institutii")
                .IsRequired();

            entity.Property(p => p.NumberDate)
                .HasColumnType("Datetime")
                .IsRequired();

            entity.Property(p => p.UserCodeAdd)
               .HasMaxLength(20)
               .IsRequired();

            entity.HasOne(u => u.UserAdd)
                .WithMany(nd => nd.FilesNumbersAdded)
                .HasForeignKey(k => k.UserCodeAdd)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_NumereDosare_Utilizator_Adaugare")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.UserLastChange)
                .WithMany(nd => nd.FilesNumbersChanged)
                .HasForeignKey(k => k.UserCodeLastChange)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_NumereDosare_Utilizator_Modificare")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.Property(p => p.UserCodeLastChange)
                .HasMaxLength(20);

            entity.Property(p => p.AddedDate)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.LastChangeDate)
                .HasColumnType("Datetime");



        }
    }
}
