using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Entities.CoinEntities;
using FinanceTracker.Data.Entities.StockEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data.Context
{
	public class FinanceTrackerDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options) : base(options) { }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Stock> Stocks { get; set; }
        DbSet<Coin> Coins { get; set; }
		DbSet<StockPortfolio> StockPortfolios { get; set; }
		DbSet<CoinPortfolio> CoinPortfolios { get; set; }


	}
}
