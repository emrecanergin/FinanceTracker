using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Data.Entities.StockEntities
{
	public class StockPortfolio 
    {
        public int Id { get; set; }
        public string PortfolioCode { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<StockAsset> StockAssets { get; set; }  = new List<StockAsset>();	
    }
}
