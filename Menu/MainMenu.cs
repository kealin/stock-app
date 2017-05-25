using StockPrices.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Menu
{
    public class MainMenu : IMainMenu
    {
        private ICsvParser _csvParser;

        public MainMenu(ICsvParser csvParser)
        {
            _csvParser = csvParser;
        }

        /// <summary
        /// Main menu
        /// </summary>
        public int? EntryScreen()
        {
            Console.Clear();
            Console.WriteLine("Specify task \n");
            Console.WriteLine("1. Refresh data based on current ticker list");
            Console.WriteLine("2. Add new ticker");
            Console.WriteLine("3. Remove existing ticker \n");

            Console.Write("Specify choice: ");

            var choice = Console.ReadKey();

            if (choice.KeyChar == '1')
            {
                return 1;
            }
            else if (choice.KeyChar == '2')
            {
                return 2;
            }
            else if (choice.KeyChar == '3')
            {
                return 3;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Specify proper choice...");
                System.Threading.Thread.Sleep(2000);
                return null;
            }
        }
    }
}
