using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AssetConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<AssetDb>();
            entity.ToTable("Assets");

            entity.HasKey(k => k.Id);
            entity.HasOne(a => a.Address)
                .WithMany(b => b.Assets)
                .HasForeignKey(k => k.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_Addresses")
                .IsRequired();

            entity.HasOne(k => k.Category)
                .WithMany(b => b.Assets)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_Categories")
                .IsRequired();

            entity.HasOne(k => k.CurrentStage)
                .WithMany(b => b.Assets)
                .HasForeignKey(k => k.CurrentStageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_Stages")
                .IsRequired();

            entity.HasOne(d => d.CurrentDecision)
                .WithMany(b => b.Assets)
                .HasForeignKey(k => k.DecisionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_Decisions")
                .IsRequired();

            entity.Property(b => b.IsDeleted)
                .IsRequired();

            entity.Property(p => p.UserCodeAdd)
              .HasMaxLength(20)
              .IsRequired();

            entity.Property(p => p.UserCodeLastChange)
                .HasMaxLength(20);

            entity.HasOne(u => u.UserAdd)
                .WithMany(nd => nd.AssetsAdded)
                .HasForeignKey(k => k.UserCodeAdd)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_User_Add")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.UserLastChange)
                .WithMany(nd => nd.AssetsChanged)
                .HasForeignKey(k => k.UserCodeLastChange)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Assets_User_Change")
                .HasPrincipalKey(k2 => k2.UserCode);


            entity.Property(p => p.AddedDate)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.LastChangeDate)
                .HasColumnType("Datetime");







        }
    }
}
