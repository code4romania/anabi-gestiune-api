using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class PersoanaConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<PersoanaDb>();
            entity.ToTable("Persoane");

            entity.HasKey(k => k.Id);
            entity.HasOne(a => a.Adresa)
                .WithMany(p => p.Persoane)
                .HasForeignKey(k => k.AdresaId)
                .HasConstraintName("FK_Persoane_Adrese")
                .IsRequired();

            entity.Property(p => p.Denumire)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(p => p.Identificator)
                .HasMaxLength(20)
                .IsRequired();
            entity.HasIndex(i => i.Identificator)
                .IsUnique()
                .HasName("indx_uq_persoane");

            entity.Property(p => p.SerieCi)
                .HasMaxLength(2);
            entity.Property(p => p.NumarCi)
                .HasMaxLength(6);

            entity.Property(p => p.EstePf).IsRequired();

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
