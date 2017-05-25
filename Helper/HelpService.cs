using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// Generic method to convert list to DataTable
        /// </summary>
        /// <remarks>
        /// https://stackoverflow.com/questions/18100783/how-to-convert-a-list-into-data-table
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
