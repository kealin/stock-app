using StockPrices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Parser
{
     public class CsvParser : ICsvParser
    {
        /// <summary>
        /// Helper for parsing the Yahoo API CSV Data into a list of stocks
        /// </summary>
        /// <param name="csvData">String containing CSV for stocks</param>
        /// <returns>List of stock objects</returns>
        public List<Stock> Parse(string csvData)
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
