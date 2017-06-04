using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class EtapePentruDecizieConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<EtapePentruDecizieDb>();
            entity.ToTable("EtapePentruDecizie");

            entity.HasKey(k => k.Id);

            entity.HasOne(u => u.Etapa)
                .WithMany(e => e.DeciziiPosibile)
                .HasForeignKey(f => f.EtapaId)
                .HasConstraintName("FK_EtapePentruDecizie_Etapa")
                .IsRequired();

            entity.HasOne(d => d.Decizie)
                .WithMany(e => e.EtapePosibile)
                .HasForeignKey(f => f.DecizieId)
                .HasConstraintName("FK_EtapePentruDecizie_Decizie")
                .IsRequired();

            entity.HasIndex(i => new { i.EtapaId, i.DecizieId }).HasName("indx_Etapa_Decizie").IsUnique();
        }
    }
}
