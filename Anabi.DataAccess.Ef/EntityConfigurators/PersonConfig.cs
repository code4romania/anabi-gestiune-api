using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class PersonConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<PersonDb>();
            entity.ToTable("Persons");

            entity.HasKey(k => k.Id);
            entity.HasOne(a => a.Address)
                .WithMany(p => p.Persons)
                .HasForeignKey(k => k.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Persons_Addresses")
                .IsRequired();

            entity.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(p => p.Identification)
                .HasMaxLength(20)
                .IsRequired();
            entity.HasIndex(i => i.Identification)
                .IsUnique()
                .HasName("indx_uq_Persons");

            entity.Property(p => p.IdSerie)
                .HasMaxLength(2);
            entity.Property(p => p.IdNumber)
                .HasMaxLength(6);

            entity.Property(p => p.IsPerson).IsRequired();

            entity.Property(p => p.UserCodeAdd)
              .HasMaxLength(20)
              .IsRequired();

            entity.Property(p => p.UserCodeLastChange)
                .HasMaxLength(20);

            entity.HasOne(u => u.UserAdd)
                .WithMany(nd => nd.PersonsAdded)
                .HasForeignKey(k => k.UserCodeAdd)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Persons_User_Add")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.UserLastChange)
                .WithMany(nd => nd.PersonsChanged)
                .HasForeignKey(k => k.UserCodeLastChange)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Persons_User_Change")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.Property(p => p.AddedDate)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.LastChangeDate)
                .HasColumnType("Datetime");

            entity.HasOne(p => p.Identifier)
                .WithMany(identifier => identifier.Persons)
                .HasForeignKey(k => k.IdentifierId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Persons_Identifiers")
                ;

        }
    }
}
