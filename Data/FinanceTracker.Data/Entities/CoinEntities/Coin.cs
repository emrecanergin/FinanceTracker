using FinanceTracker.Data.Entities.StockEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Data.Entities.CoinEntities
{
	public class Coin 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public ICollection<CoinAsset> CoinAsset { get; set; }

    }
}
