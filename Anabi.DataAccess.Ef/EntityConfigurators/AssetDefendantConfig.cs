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
        }
    }
}
