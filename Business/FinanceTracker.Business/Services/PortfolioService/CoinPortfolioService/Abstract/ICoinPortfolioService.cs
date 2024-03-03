using FinanceTracker.Business.DataTransferObjects.Coin;
using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Entities.CoinEntities;

namespace FinanceTracker.Business.Services.PortfolioService.CoinPortfolioService.Abstract
{
	public interface ICoinPortfolioService
	{
		Task<CoinPortfolio> AddCoinPortfolio(AppUser user, string name);
		Task<CoinPortfolio> GetPortfolioByCode(string code);
		Task AddToPortfolio(CoinAssetDto coinAsset, string portfolioCode);
		Task RemoveFromPortfolio(int assetId);
	}
}
