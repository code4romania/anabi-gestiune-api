using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class RecoveryBeneficiaryConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<RecoveryBeneficiaryDb>();

            entity.ToTable("RecoveryBeneficiaries");


            entity.HasKey(k => k.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasIndex(p => p.Name).IsUnique();
        }
    }
}