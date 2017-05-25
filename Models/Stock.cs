using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Models
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Bid { get; set; }
        public string Ask { get; set; }
        public string Open { get; set; }
        public string PreviousClose { get; set; }
        public string Last { get; set; }
    }
}
