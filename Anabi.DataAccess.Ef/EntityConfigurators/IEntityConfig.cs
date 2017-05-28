using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public interface IEntityConfig
    {
        void SetupEntity(ModelBuilder modelBuilder);
    }
}
