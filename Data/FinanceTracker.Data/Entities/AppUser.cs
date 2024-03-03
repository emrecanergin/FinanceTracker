using FinanceTracker.Data.Entities.CoinEntities;
using FinanceTracker.Data.Entities.StockEntities;
using Microsoft.AspNetCore.Identity;


namespace FinanceTracker.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public ICollection<StockPortfolio> StockPortfolio { get; set; } 
		public ICollection<CoinPortfolio> CoinPortfolio { get; set; } 
	}
}
