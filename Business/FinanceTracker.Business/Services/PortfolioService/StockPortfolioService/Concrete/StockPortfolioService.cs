using AutoMapper;
using FinanceTracker.Business.DataTransferObjects.Stock;
using FinanceTracker.Business.Services.PortfolioService.StockPortfolioService.Abstract;
using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Entities.StockEntities;
using FinanceTracker.Data.Repositories.EntityFramework.Abstract;

namespace FinanceTracker.Business.Services.PortfolioService.StockPortfolioService.Concrete
{
    public class StockPortfolioService(IStockPortfolioRepository portfolioRepository,
                                       IMapper mapper,
                                       IBaseRepository<StockAsset> stockAssetRepository,
                                       IBaseRepository<StockPortfolio> stockPortfolioRepository,
                                       IBaseRepository<Stock> stockRepository) : IStockPortfolioService
    {
        public async Task<StockPortfolio> AddStockPortfolio(AppUser user, string name)
        {
            var portfolio = new StockPortfolio()
            {
                User = user,
                UserId = user.Id,
                PortfolioCode = Guid.NewGuid().ToString(),
                Name = name

            };
            await portfolioRepository.Add(portfolio);
            return portfolio;
        }
        public async Task<StockPortfolio> GetPortfolioByCode(string code)
        {
            return await portfolioRepository.GetPortfolioIncludeWithStock(x => x.PortfolioCode == code);
        }
        public async Task AddToPortfolio(StockAssetDto stockAsset, string portfolioCode)
        {
            var portfoy = await portfolioRepository.Get(x => x.PortfolioCode == portfolioCode);
            StockAsset stockasset = new StockAsset();
            var mapped = mapper.Map(stockAsset, stockasset);

            var port = await stockPortfolioRepository.Get(x => x.PortfolioCode == portfolioCode);
            mapped.StockPortfolioId = port.Id;
            var stock = await stockRepository.Get(x => x.Symbol == stockAsset.Symbol);
            mapped.Stock = stock;
            await stockAssetRepository.Add(mapped);

        }
        public async Task RemoveFromPortfolio(int assetId)
        {
            await stockAssetRepository.Delete(assetId);
        }
        public async Task RemovePortfolio(string portfolioCode)
        {
            var portfolio = await portfolioRepository.Get(x => x.PortfolioCode == portfolioCode);
            await stockPortfolioRepository.Delete(portfolio.Id);
        }

    }
}
