using FinanceTracker.Data.Context;
using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Repositories.EntityFramework.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceTracker.Data.Repositories.EntityFramework.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly FinanceTrackerDbContext _context;
        public BaseRepository(FinanceTrackerDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            if (item != null)
                _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();

        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
