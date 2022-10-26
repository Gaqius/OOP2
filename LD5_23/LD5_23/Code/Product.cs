using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5_23.Code
{
    public class Product
    {
        public int WarehouseID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Product(int warehouseID, string name, int amount, decimal price)
        {
            WarehouseID=warehouseID;
            Name=name;
            Amount=amount;
            Price=price;
        }
    }
}