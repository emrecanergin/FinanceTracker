using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Data.Entities.StockEntities
{
	public class StockAsset 
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public int Quantity { get; set; }
        public decimal BuyingPrice { get; set; }
        public int StockPortfolioId { get; set; }
        public StockPortfolio StockPortfolio { get; set; }
    }
}
