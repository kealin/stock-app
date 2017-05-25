using Microsoft.Practices.Unity;
using StockPrices.Menu;
using StockPrices.Parser;
using StockPrices.Ticker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices
{
    class Program
    {
        private static IMainMenu _mainMenu;
        private static ITickerService _tickerService;

        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Init();
            int? task = _mainMenu.EntryScreen();
        }

        static void Init()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICsvParser, CsvParser>();
            container.RegisterType<IMainMenu, MainMenu>();
            container.RegisterType<ITickerService, TickerService>();
            _mainMenu = container.Resolve<IMainMenu>();
            _tickerService = container.Resolve<ITickerService>(); 
        }
    }
}
