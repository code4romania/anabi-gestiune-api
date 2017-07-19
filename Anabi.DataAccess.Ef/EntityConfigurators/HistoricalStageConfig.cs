using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class HistoricalStageConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<HistoricalStageDb>();
            entity.ToTable("HistoricalStages");
            entity.HasKey(k => k.Id);

            entity.HasOne(b => b.Asset)
                .WithMany(e => e.HistoricalStages)
                .HasForeignKey(k => k.AssetId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Assets")
                .IsRequired();

            entity.HasOne(e => e.Stage)
                .WithMany(e => e.HistoricalStages)
                .HasForeignKey(k => k.StageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Stages")
                .IsRequired();

            entity.HasOne(d => d.Decision)
                .WithMany(e => e.HistoricalStages)
                .HasForeignKey(k => k.DecizieId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Decisions")
                .IsRequired();

            entity.HasOne(i => i.IssuingInstitution)
                .WithMany(e => e.HistoricalStages)
                .HasForeignKey(k => k.InstitutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Institutions")
                .IsRequired();

            entity.Property(p => p.EstimatedAmountCurrency)
                .HasMaxLength(3)
                .IsRequired();
            entity.Property(p => p.EstimatedAmount)
                .HasColumnType("Decimal(20,2)")
                .IsRequired();

            entity.Property(p => p.UserCodeAdd)
               .HasMaxLength(20)
               .IsRequired();

            entity.Property(p => p.UserCodeLastChange)
                .HasMaxLength(20);

            entity.HasOne(u => u.UserAdd)
                .WithMany(nd => nd.HistoricalStagesAdded)
                .HasForeignKey(k => k.UserCodeAdd)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Utilizator_Add")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.UserLastChange)
                .WithMany(nd => nd.HistoricalStagesChanged)
                .HasForeignKey(k => k.UserCodeLastChange)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Utilizator_Change")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.Person)
                .WithMany(h => h.HistoricalStages)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_OwnerId");

            entity.Property(p => p.AddedDate)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.LastChangeDate)
                .HasColumnType("Datetime");

            entity.Property(p => p.LegalBasis)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(p => p.DecisionNumber)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(p => p.DecisionDate)
                .HasColumnType("Date")
                .IsRequired();

            entity.Property(p => p.AssetState)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.OwnerId)
                .HasColumnType("Int");

            entity.Property(p => p.ActualValue)
                .HasColumnType("Decimal(20, 2)");

            entity.Property(p => p.ActualValueCurrency)
                .HasMaxLength(3)
                .IsRequired();

        }
    }
}
