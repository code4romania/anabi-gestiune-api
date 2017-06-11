using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class EtapaIstoricaConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<EtapaIstoricaDb>();
            entity.ToTable("EtapeIstorice");
            entity.HasKey(k => k.Id);

            entity.HasOne(b => b.Bun)
                .WithMany(e => e.IstoricEtape)
                .HasForeignKey(k => k.BunId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EtapeIstorice_Bunuri")
                .IsRequired();

            entity.HasOne(e => e.Etapa)
                .WithMany(e => e.EtapeIstorice)
                .HasForeignKey(k => k.EtapaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EtapeIstorice_Etape")
                .IsRequired();

            entity.HasOne(d => d.Decizia)
                .WithMany(e => e.EtapeIstorice)
                .HasForeignKey(k => k.DecizieId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EtapeIstorice_Decizii")
                .IsRequired();

            entity.HasOne(i => i.InstitutiaEmitenta)
                .WithMany(e => e.EtapeIstorice)
                .HasForeignKey(k => k.InstitutieId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EtapeIstorice_Institutii")
                .IsRequired();

            entity.Property(p => p.ValutaEstimare)
                .HasMaxLength(3)
                .IsRequired();
            entity.Property(p => p.ValoareEstimata)
                .HasColumnType("Decimal(20,2)")
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

            entity.Property(p => p.TemeiJuridic)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(p => p.NumarDecizie)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(p => p.DataDeciziei)
                .HasColumnType("Date")
                .IsRequired();

        }
    }
}
