using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;

namespace Anabi.Domain
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
