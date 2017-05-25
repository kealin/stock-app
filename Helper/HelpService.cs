using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Helper
{
    public class HelpService : IHelpService
    {
        /// <summary>
        /// Builds predicate based on user input
        /// </summary>
        /// <remarks>
        /// Currently supports ticker list only
        /// </remarks>
        public String BuildPredicate()
        {
            //http://finance.yahoo.com/d/quotes.csv?s=+ +&f=snbaopl
            return "thepredicate";
        }
    }
}
