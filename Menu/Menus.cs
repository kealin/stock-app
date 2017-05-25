using StockPrices.Parser;
using StockPrices.Ticker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Menu
{
    public class Menus : IMenus
    {
        private ICsvParser _csvParser;
        private ITickerService _tickerService;

        public Menus(ICsvParser csvParser, ITickerService tickerService)
        {
            _csvParser = csvParser;
            _tickerService = tickerService;
        }

        /// <summary
        /// Main menu
        /// </summary>
        public void EntryScreen()
        {
            Console.Clear();
            Console.WriteLine("Specify task \n");
            Console.WriteLine("1. Refresh data based on current ticker list");
            Console.WriteLine("2. Add new ticker");
            Console.WriteLine("3. Remove existing ticker \n");

            Console.Write("Specify choice: ");

            var task = Console.ReadKey().KeyChar;

            switch (task)
            {
                case '1':
                    RefreshData();
                    break;
                case '2':
                    AddNewTicker();
                    break;
                case '3':
                    RemoveExistingTicker();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Specify proper choice...");
                    System.Threading.Thread.Sleep(2000);
                    EntryScreen();
                    break;
            }
   
        }

        public void RefreshData()
        {
            Console.Clear();
            Console.WriteLine("Refreshing data based on ticker list..");
            _tickerService.Refresh();
            Console.WriteLine("Data refreshed");
            System.Threading.Thread.Sleep(2000);
            EntryScreen();
        }

        public void AddNewTicker()
        {
            Console.Clear();
            _tickerService.AddNewTicker();
            System.Threading.Thread.Sleep(2000);
            EntryScreen();
        }

        public void RemoveExistingTicker()
        {
            Console.Clear();
            _tickerService.RemoveExistingTicker();
            EntryScreen();
        }
    }
}
