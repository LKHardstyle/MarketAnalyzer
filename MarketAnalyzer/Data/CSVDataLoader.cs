using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAnalyzer.Data
{
    public class CSVDataLoader
    {
        //Combines Path of Dataset with Application
        private static string datasetPath = Path.Combine(Application.StartupPath, "Data/amazon_small_dataset.csv");
        //RecordLimit of the Dataset
        private const int dataLimit = 800000;
        
        public static List<Product> LoadData()
        {
            //Creating new FileReader and CsvReader
            using (var reader = new StreamReader(datasetPath))             
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //Registers ProductMap Class
                csv.Context.RegisterClassMap<ProductMap>();
                //List of products containing the Mapped Dataset
                List<Product> products = csv.GetRecords<Product>().Take(dataLimit).ToList();
                //Return the Mapped Product List
                return products;
            }
        }
    }
}
