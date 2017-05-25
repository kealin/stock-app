using StockPrices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Excel
{
    public interface IExcelService
    {
        void PopulateExcel(List<Stock> stocks);
    }
}
