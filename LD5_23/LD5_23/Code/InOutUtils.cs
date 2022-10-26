using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Web;

namespace LD5_23.Code
{
    public class InOutUtils
    {
        /// <summary>
        /// Reads data from files
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Product> ReadProducts (string fileName)
        {
            List<Product> products = new List<Product>();

            using (var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                int wareHouseID = Convert.ToInt32(reader.ReadLine());
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length != 3)
                    {
                        throw new Exception($"Invalid product line: '{line}'");
                    }
                    string productName = parts[0];
                    int productAmount = Convert.ToInt32(parts[1]);
                    decimal productPrice = Convert.ToDecimal(parts[2]);
                    Product product = new Product(wareHouseID, productName, productAmount, productPrice);
                    products.Add(product);
                }
            }
            return products;
        }
        public static Order ReadOrder (string fileName)
        {
            using (var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(';');
                if (parts.Length != 3)
                {
                    throw new Exception($"Invalid order line: '{line}'");
                }
                string name = parts[0];
                int amount = Convert.ToInt32(parts[1]);
                decimal price = Convert.ToDecimal(parts[2]);
                Order order = new Order(name, amount, price);
                return order;
            }            
        }
        /// <summary>
        /// Reads data from entire directory
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Product> ReadProductsDir(string directory, string pattern = "*.txt")
        {
            if (!Directory.Exists(directory))
            {
                throw new Exception(string.Format("Directory '{0}' not found", directory));
            }
            var merged = new List<Product>();
            foreach (var fileName in Directory.GetFiles(directory, pattern))
            {
                merged.AddRange(ReadProducts(fileName));
            }
            return merged;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="products"></param>
        public static void PrintProduct (ResultsWriter writer, IEnumerable<Product> products)
        {
            foreach (var tuple in writer.WriteTable(products, "Sandelio numeris", "Vardas", "Kiekis", "Kaina"))
            {
                var product = tuple.Item1;
                var row = tuple.Item2;
                row.Add(product.WarehouseID);
                row.Add(product.Name);
                row.Add(product.Amount);
                row.Add(product.Price);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="order"></param>
        public static void PrintOrder (ResultsWriter writer, Order order)
        {
            foreach (var tuple in writer.WriteTable(new List<Order> {order}, "Vardas", "Kiekis", "Kainos riba"))
            {
                var product = tuple.Item1;
                var row = tuple.Item2;
                row.Add(order.Name);
                row.Add(order.Amount);
                row.Add(order.PriceLimit);
            }
        }
    }
}