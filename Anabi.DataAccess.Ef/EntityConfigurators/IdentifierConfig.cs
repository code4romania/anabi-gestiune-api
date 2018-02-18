using System;
using System.Collections.Generic;
using System.Text;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class IdentifierConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<IdentifierDb>();

            entity.HasOne(u => u.UserAdd)
                .WithMany(nd => nd.IdentifiersAdded)
                .HasForeignKey(k => k.UserCodeAdd)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Identifiers_User_Add")
                .HasPrincipalKey(k2 => k2.UserCode);

            entity.HasOne(u => u.UserLastChange)
                .WithMany(nd => nd.IdentifiersChanged)
                .HasForeignKey(k => k.UserCodeLastChange)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Identifiers_User_Change")
                .HasPrincipalKey(k2 => k2.UserCode);
        }
    }
}
