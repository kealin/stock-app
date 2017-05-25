using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.File
{
    public interface IFileService
    {
        void WriteToFile(String ticker);
        void RemoveFromFile(String ticker);
        List<String> GetAll();
    }
}
