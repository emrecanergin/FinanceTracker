using FinanceTracker.Data.Entities.CoinEntities;
using FinanceTracker.Data.Entities.StockEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Data.Repositories.EntityFramework.Abstract
{
	public interface ICoinPortfolioRepository : IBaseRepository<CoinPortfolio>
	{
		Task<CoinPortfolio> GetPortfolioIncludeWithCoin(Expression<Func<CoinPortfolio, bool>> predicate);
	}
}
