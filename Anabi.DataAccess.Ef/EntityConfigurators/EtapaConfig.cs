using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class EtapaConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<EtapaDb>();
            entity.ToTable("Etape");
            entity.HasKey(k => k.Id);
            entity.Property(p => p.Denumire).HasMaxLength(50).IsRequired();
            entity.HasIndex(i => i.Denumire).HasName("indx_uq_denumireetapa").IsUnique();

            entity.Property(p => p.EsteFinala).IsRequired();



        }
    }
}
