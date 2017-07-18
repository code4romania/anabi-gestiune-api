﻿using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.DataAccess.Abstractions.Repositories;

namespace Anabi.DataAccess.Repositories
{
   public class CountiesRepository : GenericRepository<CountyDb>
    {
        public CountiesRepository(AnabiContext ctx) : base(ctx)
        {

        }

    }
}