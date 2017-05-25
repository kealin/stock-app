using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Helper
{
    public class HelpService : IHelpService
    {
        private readonly string baseUrl = "http://finance.yahoo.com/d/quotes.csv";

        public HelpService()
        {

        }

        /// <summary>
        /// Builds predicate based on user input
        /// </summary>
        /// <remarks>
        /// Currently supports ticker list only
        /// </remarks>
        public String BuildPredicate(List<String> tickers)
        {
            var predicateUrl = baseUrl + "?s=";
            foreach(string ticker in tickers)
            {
                predicateUrl += ticker + "+";
            }
            predicateUrl += "&f=snbaopl";
            return predicateUrl;
        }
    }
}
