using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5_23.Code
{
    public class Order
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal PriceLimit { get; set; }
        public Order(string name, int amount, decimal priceLimit)
        {
            Name=name;
            Amount=amount;
            PriceLimit=priceLimit;
        }
    }
}