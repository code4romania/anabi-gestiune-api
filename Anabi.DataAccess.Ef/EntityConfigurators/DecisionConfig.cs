using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class DecisionConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<DecisionDb>();
            entity.ToTable("Decisions");

            entity.HasKey(k => k.Id);
            entity.Property(p => p.Name).HasMaxLength(50).IsRequired();
            entity.HasIndex(i => i.Name).HasName("indx_uq_Decision").IsUnique();



        }
    }
}
