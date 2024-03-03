using FinanceTracker.Data.Context;
using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Entities.StockEntities;
using FinanceTracker.Data.Repositories.EntityFramework.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceTracker.Data.Repositories.EntityFramework.Concrete
{
    public class StockPortfolioRepository : BaseRepository<StockPortfolio> , IStockPortfolioRepository
    {
        private readonly FinanceTrackerDbContext _context;
        public StockPortfolioRepository(FinanceTrackerDbContext context) : base(context)
        {
            _context = context;
        }
		public async Task<StockPortfolio> GetPortfolioIncludeWithStock(Expression<Func<StockPortfolio, bool>> predicate)
		{
            var portfolio = await _context.Set<StockPortfolio>().Include(x => x.StockAssets).ThenInclude(x=>x.Stock).FirstOrDefaultAsync(predicate);
            return portfolio;
		}
	}
}
