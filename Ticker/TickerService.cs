using StockPrices.Models;
using StockPrices.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Ticker
{
   public class TickerService : ITickerService
    {
        /// <summary
        /// Refreshes data based on current ticker list
        /// </summary>
        /// <remarks>
        /// Ticker list fetched from Tickers.txt at project root
        /// </remarks>
      /*  public void RefreshData()
         {
             Console.Clear();
             string csvData;

             using (WebClient web = new WebClient())
             {
                 csvData = web.DownloadString("1");
             }

             List<Stock> stocks = CsvParser.Parse(csvData);

             foreach (Stock stock in stocks)
             {
                 Console.WriteLine(string.Format("{0} ({1})  Bid:{2} Offer:{3} Last:{4} Open: {5} PreviousClose:{6}", stock.Name, stock.Symbol, stock.Bid, stock.Ask, stock.Last, stock.Open, stock.PreviousClose));
             }

             Console.WriteLine("Refreshing data...");
         } */

        /// <summary>
        /// Adds new ticker based on user input
        /// </summary>
        /// <remarks>
        /// Ticker list Tickers.txt located at project root
        /// </remarks>
        public void AddNewTicker()
        {
            Console.Clear();
            Console.Write("Specify ticker: ");
            var ticker = Console.ReadLine();
        }

        /// <summary>
        /// Removes existing ticker based on user input
        /// </summary>
        /// <remarks>
        /// Ticker list Tickers.txt located at project root
        /// </remarks>
        public void RemoveExistingTicker()
        {
            Console.Clear();
            Console.Write("Specify ticker: ");
            var ticker = Console.ReadLine();
        }
    }
}
