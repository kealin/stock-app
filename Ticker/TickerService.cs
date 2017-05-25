using StockPrices.File;
using StockPrices.Helper;
using StockPrices.Models;
using StockPrices.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Ticker
{
    public class TickerService : ITickerService
    {
        private IFileService _file;
        private IHelpService _helper;
        private ICsvParser _csvService;

        public TickerService(IFileService file, IHelpService helper, ICsvParser csvService)
        {
            _file = file;
            _helper = helper;
            _csvService = csvService;
        }

        /// <summary
        /// Refreshes data based on current ticker list
        /// </summary>
        /// <remarks>
        /// Ticker list fetched from Tickers.txt at project root
        /// </remarks>
        public void Refresh()
        {
            string data;
            var tickers = _file.GetAll();
            var url = _helper.BuildPredicate(tickers);
            using (WebClient web = new WebClient())
            {
                 data = web.DownloadString(url);
            }

            List<Stock> stocks = _csvService.Parse(data);
        }

        /// <summary>
        /// Adds new ticker based on user input
        /// </summary>
        /// <remarks>
        /// Ticker list Tickers.txt located at project root
        /// </remarks>
        public void AddNewTicker()
        {
            Console.Write("Specify ticker to add: ");
            var ticker = Console.ReadLine();
            _file.WriteToFile(ticker);
        }

        /// <summary>
        /// Removes existing ticker based on user input
        /// </summary>
        /// <remarks>
        /// Ticker list Tickers.txt located at project root
        /// </remarks>
        public void RemoveExistingTicker()
        {
            Console.WriteLine("Current tickers: " + Environment.NewLine);
            var tickers = _file.GetAll();

            foreach (string t in tickers)
            {
                Console.WriteLine(t);
            }

            Console.Write("Specify ticker to remove: ");
            var ticker = Console.ReadLine();
            _file.RemoveFromFile(ticker);
        }
    }
}
