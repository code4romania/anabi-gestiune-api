using System;
using System.Collections.Generic;
using System.Text;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class AssetDefendantConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AssetDefendantDb>();

            entity.HasOne(u => u.UserAdd)
               .WithMany(nd => nd.AssetDefendantsAdded)
               .HasForeignKey(k => k.UserCodeAdd)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_AssetDefendants_User_Add")
               .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.UserLastChange)
                .WithMany(nd => nd.AssetDefendantsChanged)
                .HasForeignKey(k => k.UserCodeLastChange)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AssetDefendants_User_Change")
                .HasPrincipalKey(k2 => k2.UserCode);
        }
    }
}
