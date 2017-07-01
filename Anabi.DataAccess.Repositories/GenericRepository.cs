using Anabi.DataAccess.Abstractions.Repositories;
using Anabi.DataAccess.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Anabi.DataAccess.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        protected AnabiContext context;

        public GenericRepository(AnabiContext ctx)
        {
            context = ctx;
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = context.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = context.Set<T>();
            return query;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
