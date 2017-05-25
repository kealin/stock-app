﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPrices.File
{
    public class FileService : IFileService
    {
        private static readonly String appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly String tickerFilePath = Path.Combine(appDataPath + "\\Tickers.txt");

        public FileService()
        {

        }

        public void WriteToFile(String ticker)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(tickerFilePath, true))
                {
                    sw.WriteLine(ticker);
                    sw.Close();
                }
            }
            catch (IOException ex)
            {
                // Append error handling & logging
            }
        }

        public void RemoveFromFile(String ticker)
        {
            List<String> tickers = new List<String>();

            try
            {
                using (StreamReader reader = new StreamReader(tickerFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        tickers.Add(reader.ReadLine());
                    }           
                }
                var tickersToKeep = tickers.Where(l => l != ticker).ToList();
                System.IO.File.WriteAllLines(tickerFilePath, tickersToKeep);
            }
            catch (IOException ex)
            {
                // Append error handling & logging
            }
        }

        public List<String> GetAll()
        {
            List<String> tickers = new List<String>();

            try
            {
                using (StreamReader reader = new StreamReader(tickerFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        tickers.Add(reader.ReadLine());
                    }
                }
            }
            catch (IOException ex)
            {
                // Append error handling & logging
            }
            return tickers;
        }
    }
}
