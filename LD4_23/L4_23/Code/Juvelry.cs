using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4_23.Code
{
    public abstract class Juvelry
    {
        public string Type { get; set; }
        public string ShopName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Maker { get; set; }
        public string Name { get; set; }
        public string Metal { get; set; }
        public int Weight { get; set; }
        public int Carat { get; set; }
        public int Price { get; set; }
        protected Juvelry(string type, string shopName, string adress, string phoneNumber, string maker, string name, string metal, int weight, int carat, int price)
        {
            Type=type;
            ShopName=shopName;
            Adress=adress;
            PhoneNumber=phoneNumber;
            Maker=maker;
            Name=name;
            Metal=metal;
            Weight=weight;
            Carat=carat;
            Price=price;
        }
        /// <summary>
        /// Serialize a Juvelry into a valid CSV line
        /// </summary>
        /// <returns></returns>
        public abstract string ToCSVLine();
    }
}