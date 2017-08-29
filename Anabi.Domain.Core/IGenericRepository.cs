using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Anabi.Domain
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);
        Task SaveAsync();
    }
}
