using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class JudetConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<JudetDb>();

            entity.ToTable("Judete");
            

            entity.HasKey(k => k.Id);
            entity.Property(p => p.Abreviere)
                .IsRequired()
                .HasMaxLength(2);

            entity.Property(p => p.Denumire)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasIndex(i => i.Abreviere).IsUnique();
            
        }
    }
}
