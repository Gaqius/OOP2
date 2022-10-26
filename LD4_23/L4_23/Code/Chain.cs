using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4_23.Code
{
    public class Chain : Juvelry
    {
        public int Lenght { get; set; }

        public Chain(string Type, string shopName, string adress, string phoneNumber, string maker, string name, string metal, int weight, int carat, int price, int lenght)
            : base(Type, shopName, adress, phoneNumber, maker, name, metal, weight, carat, price)
        {
            Lenght=lenght;
        }
        /// <summary>
        /// Compares Chains
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Chain other)
        {
            int thisSize = this.Lenght;
            int otherSize = other.Lenght;
            if (thisSize < otherSize)
            {
                return -1;
            }
            else if (thisSize > otherSize) return 1;
            else return 0;
        }
        /// <summary>
        /// Formats Chains into correct CSV lines
        /// </summary>
        /// <returns></returns>
        public override string ToCSVLine()
        {
            return string.Join(";", Maker, Name, Metal, Weight, Carat, Price, Lenght);
        }
    }
}