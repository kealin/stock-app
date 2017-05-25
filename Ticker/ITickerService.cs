using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Ticker
{
    public interface ITickerService
    {
        void AddNewTicker();
        void RemoveExistingTicker();
        void Refresh();
    }
}
