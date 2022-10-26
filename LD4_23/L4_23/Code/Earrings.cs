using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4_23.Code
{
    public class Earrings : Juvelry
    {
        public string ClaspType { get; set; }

        public Earrings(string Type, string shopName, string adress, string phoneNumber, string maker, string name, string metal, int weight, int carat, int price, string claspType)
            : base(Type, shopName, adress, phoneNumber, maker, name, metal, weight, carat, price)
        {
            ClaspType=claspType;
        }
        /// <summary>
        /// Compare Earrings
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Earrings other)
        {
            int thisSize = this.Weight;
            int otherSize = other.Weight;
            if (thisSize < otherSize)
            {
                return -1;
            }
            else if (thisSize > otherSize) return 1;
            else return 0;
        }
        /// <summary>
        /// Formats Earrings into correct CSV lines
        /// </summary>
        /// <returns></returns>
        public override string ToCSVLine()
        {
            return string.Join(";", Maker, Name, Metal, Weight, Carat, Price, ClaspType);
        }
    }
}