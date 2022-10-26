using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4_23.Code
{
    public class Ring : Juvelry
    {
        public int size { get; set; }

        public Ring(string Type, string shopName, string adress, string phoneNumber, string maker, string name, string metal, int weight, int carat, int price, int size)
            : base(Type ,shopName, adress, phoneNumber, maker, name, metal, weight, carat, price)
        {
            this.size=size;
        }
        /// <summary>
        /// Compares Rings
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Ring other)
        {
            int thisSize = this.size;
            int otherSize = other.size;
            if (thisSize < otherSize)
            {
                return -1;
            }
            else if (thisSize > otherSize) return 1;
            else return 0;
        }
        /// <summary>
        /// Formats Rings into correct CSV lines
        /// </summary>
        /// <returns></returns>
        public override string ToCSVLine()
        {
            return string.Join(";", Maker, Name, Metal, Weight, Carat, Price, size);
        }
    }
}