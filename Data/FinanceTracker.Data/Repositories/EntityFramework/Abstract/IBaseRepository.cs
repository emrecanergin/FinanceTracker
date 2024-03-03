using FinanceTracker.Data.Entities;
using System.Linq.Expressions;

namespace FinanceTracker.Data.Repositories.EntityFramework.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
