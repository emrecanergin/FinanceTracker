using FinanceTracker.Data.Context;
using FinanceTracker.Data.Entities.CoinEntities;
using FinanceTracker.Data.Entities.StockEntities;
using FinanceTracker.Data.Repositories.EntityFramework.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceTracker.Data.Repositories.EntityFramework.Concrete
{
	public class CoinPortfolioRepository : BaseRepository<CoinPortfolio>, ICoinPortfolioRepository
	{
		private readonly FinanceTrackerDbContext _context;
		public CoinPortfolioRepository(FinanceTrackerDbContext context) : base(context)
		{
			_context = context;
		}
		public async Task<CoinPortfolio> GetPortfolioIncludeWithCoin(Expression<Func<CoinPortfolio, bool>> predicate)
		{
			var portfolio = await _context.Set<CoinPortfolio>().Include(x => x.CoinAssets).ThenInclude(x => x.Coin).FirstOrDefaultAsync(predicate);
			return portfolio;
		}
	}
}
