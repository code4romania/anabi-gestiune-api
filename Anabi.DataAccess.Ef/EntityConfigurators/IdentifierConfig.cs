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

            
        }
    }
}
