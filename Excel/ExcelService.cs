using ClosedXML.Excel;
using StockPrices.Helper;
using StockPrices.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.Excel
{
    public class ExcelService : IExcelService 
    {
        private IHelpService _helper;
        private static readonly String appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly String stocksFilePath = Path.Combine(appDataPath + "\\Stocks.xlsx");

        public ExcelService(IHelpService helper)
        {
            _helper = helper;
        }

        public void PopulateExcel(List<Stock> stocks)
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                DataTable dt = _helper.ToDataTable(stocks);
                workbook.Worksheets.Add(dt);
                workbook.SaveAs(stocksFilePath);
            }
            catch (IOException ex)
            {
                // Handle IO exception & log
            }
            catch (Exception ex)
            {
                // Handle other exceptions & log
            }
        }
    }
}
