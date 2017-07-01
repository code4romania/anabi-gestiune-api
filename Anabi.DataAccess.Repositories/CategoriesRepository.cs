using Anabi.DataAccess.Abstractions.Repositories;
using Anabi.DataAccess.Ef.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using Anabi.DataAccess.Ef;

namespace Anabi.DataAccess.Repositories
{
    public class CategoriesRepository : GenericRepository<CategoryDb>
    {
        public CategoriesRepository(AnabiContext ctx) : base(ctx)
        {

        }

    }
}
