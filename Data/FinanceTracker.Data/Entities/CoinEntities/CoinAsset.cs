using FinanceTracker.Data.Entities.StockEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Data.Entities.CoinEntities
{
	public class CoinAsset 
    {
        public int Id { get; set; }     
        public int CoinId { get; set; } 
        public Coin Coin { get; set; }
        public int Quantity { get; set; }
        public decimal BuyingPrice { get; set; }
        public int CoinPortfolioId { get; set; }
        public CoinPortfolio CoinPortfolio { get; set; }
    }
}
