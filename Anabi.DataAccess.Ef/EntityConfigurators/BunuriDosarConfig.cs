using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class BunuriDosarConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<BunuriDosarDb>();
            entity.ToTable("BunuriDosare");

            entity.HasKey(k => k.Id);

            entity.HasOne(b => b.Bun)
                .WithMany(d => d.DosareBun)
                .HasForeignKey(k => k.BunId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_BunuriDosare_Bunuri")
                .IsRequired();

            entity.HasOne(d => d.Dosar)
                .WithMany(b => b.BunuriDosar)
                .HasForeignKey(k => k.DosarId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_BunuriDosare_Dosare")
                .IsRequired();

            entity.Property(p => p.CodUtilizatorAdaugare)
              .HasMaxLength(20)
              .IsRequired();

            entity.Property(p => p.CodUtilizatorUltimaModificare)
                .HasMaxLength(20);

            entity.Property(p => p.DataAdaugare)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.DataUltimeiModificari)
                .HasColumnType("Datetime");
        }
    }
}
