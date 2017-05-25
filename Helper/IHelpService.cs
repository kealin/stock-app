using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Helper
{
    public interface IHelpService
    {
        String BuildPredicate(List<String> tickers);
        DataTable ToDataTable<T>(List<T> items);
        void HandleIOException();
        void HandleGeneralException(Exception exception);
    }
}
