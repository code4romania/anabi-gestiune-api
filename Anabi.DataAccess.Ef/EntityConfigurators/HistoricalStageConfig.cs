using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class HistoricalStageConfig : BaseEntityConfig<HistoricalStageDb>
    {
        public override void Configure(EntityTypeBuilder<HistoricalStageDb> builder)
        {
            builder.HasOne(b => b.Asset)
                .WithMany(e => e.HistoricalStages)
                .HasForeignKey(k => k.AssetId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Assets")
                .IsRequired();

            builder.HasOne(e => e.Stage)
                .WithMany(e => e.HistoricalStages)
                .HasForeignKey(k => k.StageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Stages")
                .IsRequired();

            builder.HasOne(d => d.Decision)
                .WithMany(e => e.HistoricalStages)
                .HasForeignKey(k => k.DecizieId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Decisions");

            builder.HasOne(i => i.IssuingInstitution)
                .WithMany(e => e.HistoricalStages)
                .HasForeignKey(k => k.InstitutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HistoricalStages_Institutions");

            builder.Property(p => p.EstimatedAmountCurrency)
                .HasMaxLength(3);

            builder.Property(p => p.EstimatedAmount)
                .HasColumnType("Decimal(20,2)");


            builder.HasOne(u => u.Person)
                .WithMany(h => h.HistoricalStages)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_OwnerId");



            builder.Property(p => p.LegalBasis)
                .HasMaxLength(200);

            builder.Property(p => p.DecisionNumber)
                .HasMaxLength(50);

            builder.Property(p => p.DecisionDate)
                .HasColumnType("Date");

            builder.Property(p => p.AssetState)
                .HasMaxLength(100);

            builder.Property(p => p.OwnerId)
                .HasColumnType("Int");

            builder.Property(p => p.ActualValue)
                .HasColumnType("Decimal(20, 2)");

            builder.Property(p => p.ActualValueCurrency)
                .HasMaxLength(3);

            base.Configure(builder);
        }
    }
}
