using StockPrices;
using StockPrices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Parser
{
    public interface ICsvParser
    {
        List<Stock> Parse(string csvData);
    }
}
