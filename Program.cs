using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace stock_prices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Specify task \n");
            Console.WriteLine("1. Refresh data based on current ticker list");
            Console.WriteLine("2. Add new ticker");
            Console.WriteLine("3. Remove existing ticker");

            int choice = Console.Read();

            if(choice == 1)
            {
                RefreshData();
            } else if (choice == 2)
            {
                AddNewTicker();
            } else if (choice == 3)
            {
                RemoveExistingTicker();
            }

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

            Console.Read();
        }

        /// <summary>
        /// Refreshes data based on current ticker list
        /// </summary>
        /// <remarks>
        /// Ticker list fetched from Tickers.txt at project root
        /// </remarks>
        static void RefreshData()
        {

        }

        /// <summary>
        /// Adds new ticker based on user input
        /// </summary>
        /// <remarks>
        /// Ticker list Tickers.txt located at project root
        /// </remarks>
        static void AddNewTicker()
        {

        }

        /// <summary>
        /// Removes existing ticker based on user input
        /// </summary>
        /// <remarks>
        /// Ticker list Tickers.txt located at project root
        /// </remarks>
        static void RemoveExistingTicker()
        {

        }

        /// <summary>
        /// Builds predicate based on user input
        /// </summary>
        /// <remarks>
        /// Currently supports ticker list only
        /// </remarks>
        static void BuildPredicate()
        {
            //http://finance.yahoo.com/d/quotes.csv?s=+ +&f=snbaopl
        }
    }
}
