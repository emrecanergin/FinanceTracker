using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Data.Entities.CoinEntities
{
	public class CoinPortfolio
    {
        public int Id { get; set; }
        public string PortfolioCode { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<CoinAsset> CoinAssets { get; set; } = new List<CoinAsset>();  
    }
}
