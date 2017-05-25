using Microsoft.Practices.Unity;
using StockPrices.File;
using StockPrices.Helper;
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
        private static IMenus _menus;

        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Init();
             _menus.EntryScreen();
        }

        static void Init()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICsvParser, CsvParser>();
            container.RegisterType<IMenus, Menus>();
            container.RegisterType<ITickerService, TickerService>();
            container.RegisterType<IHelpService, HelpService>();
            container.RegisterType<IFileService, FileService>();
            _menus = container.Resolve<IMenus>();
        }
    }
}
