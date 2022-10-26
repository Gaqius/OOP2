using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace L4_23.Code
{
    public class InOutUtils
    {
        /// <summary>
        /// Reads Juvelries
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Juvelry> ReadJuvelry (string fileName)
        {
            List<Juvelry> list = new List<Juvelry>();

            using (var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                
                string ShopName = reader.ReadLine();
                string Adress = reader.ReadLine();
                string Phone = reader.ReadLine();

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string Type = parts[0].Trim();
                    string Maker = parts[1].Trim();
                    string Name = parts[2].Trim();
                    string Metal = parts[3].Trim();
                    int Weight = Convert.ToInt32(parts[4].Trim());
                    int Carat = Convert.ToInt32(parts[5].Trim());
                    int Price = Convert.ToInt32(parts[6].Trim());
                    if (Type == "Ring")
                    {
                        int Size = Convert.ToInt32(parts[7].Trim());
                        Ring ring = new Ring(Type, ShopName, Adress, Phone, Maker, Name, Metal, Weight, Carat, Price, Size);
                        list.Add(ring);
                    }
                    else if (Type == "Earrings")
                    {
                        string ClaspType = parts[7].Trim();
                        Earrings earrings = new Earrings(Type, ShopName, Adress, Phone, Maker, Name, Metal, Weight, Carat, Price, ClaspType);
                        list.Add(earrings);
                    }
                    else if (Type == "Chain")
                    {
                        int Lenght = Convert.ToInt32(parts[7].Trim());
                        Chain chain = new Chain(Type, ShopName, Adress, Phone, Maker, Name, Metal, Weight, Carat, Price, Lenght);
                        list.Add(chain);
                    }
                    else
                    {
                        throw new Exception($"Invalid number of values given: '{line}'");
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Read Juvelries from Directory
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Juvelry> ReadJuvelryDir(string directory, string pattern = "*.txt")
        {
            if (!Directory.Exists(directory))
            {
                throw new Exception(string.Format("Directory '{0}' not found", directory));
            }
            var merged = new List<Juvelry>();
            foreach (var fileName in Directory.GetFiles(directory, pattern))
            {
                merged.AddRange(ReadJuvelry(fileName));
            }
            return merged;
        }
        
    }
}