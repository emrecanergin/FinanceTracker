using AutoMapper;
using FinanceTracker.Business.DataTransferObjects.Coin;
using FinanceTracker.Business.Services.PortfolioService.CoinPortfolioService.Abstract;
using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Entities.CoinEntities;
using FinanceTracker.Data.Repositories.EntityFramework.Abstract;

namespace FinanceTracker.Business.Services.PortfolioService.StockPortfolioService.Concrete
{
    public class CoinPortfolioService(ICoinPortfolioRepository coinPortfolioRepository,
									   IMapper mapper,
									   IBaseRepository<CoinAsset> coinAssetRepository,								  
									   IBaseRepository<Coin> stockRepository) : ICoinPortfolioService
	{
		public async Task<CoinPortfolio> AddCoinPortfolio(AppUser user, string name)
		{
			var portfolio = new CoinPortfolio()
			{
				User = user,
				UserId = user.Id,
				PortfolioCode = Guid.NewGuid().ToString(),
				Name = name

			};
			await coinPortfolioRepository.Add(portfolio);
			return portfolio;
		}
		public async Task<CoinPortfolio> GetPortfolioByCode(string code)
		{
			return await coinPortfolioRepository.GetPortfolioIncludeWithCoin(x => x.PortfolioCode == code);
		}
		public async Task AddToPortfolio(CoinAssetDto coinAsset, string portfolioCode)
		{
			
			var portfoy = await coinPortfolioRepository.Get(x => x.PortfolioCode == portfolioCode);
			CoinAsset coinasset = new CoinAsset();
			var mapped = mapper.Map(coinAsset, coinasset);

			var port = await coinPortfolioRepository.Get(x => x.PortfolioCode == portfolioCode);
			mapped.CoinPortfolioId = port.Id;
			var stock = await stockRepository.Get(x => x.Symbol == coinAsset.Symbol);
			mapped.Coin = stock;
			await coinAssetRepository.Add(mapped);

		}
		public async Task RemoveFromPortfolio(int assetId)
		{
			await coinAssetRepository.Delete(assetId);
		}
	}
}
