using StockPrices.Helper;
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
                p.Symbol = cols[0].Replace("\"", "");
                p.Name = cols[1].Replace("\"", ""); ;
                p.Bid = cols[2].Replace("\"", ""); ;
                p.Ask = cols[3].Replace("\"", ""); ;
                p.Open = cols[4].Replace("\"", ""); ;
                p.PreviousClose = cols[5].Replace("\"", ""); ;
                p.Last = cols[6].Replace("\"", ""); ;
                stocks.Add(p);
            }

            return stocks;
        }
    }
}
