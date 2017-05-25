using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_prices
{
     public class CsvParser
    {
        public static List<Stock> Parse(string csvData)
        {
            List<Stock> stocks = new List<Stock>();

            string[] rows = csvData.Replace("\r", "").Split('\n');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;

                string[] cols = row.Split(',');

                Stock p = new Stock();
                p.Symbol = cols[0];
                p.Name = cols[1];
                p.Bid = Convert.ToDecimal(cols[2]);
                p.Ask = Convert.ToDecimal(cols[3]);
                p.Open = Convert.ToDecimal(cols[4]);
                p.PreviousClose = Convert.ToDecimal(cols[5]);
                p.Last = Convert.ToDecimal(cols[6]);

                stocks.Add(p);
            }

            return stocks;
        }
    }
}
