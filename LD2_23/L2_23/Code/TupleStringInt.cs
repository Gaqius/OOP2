using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2_23.Code
{
    /// <summary>
    /// TupleStringInt class
    /// </summary>
    public class TupleStringInt : IComparable
    {        
        public string Item1 { get; set; }
        public int Item2 { get; set; }
        public TupleStringInt(string item1, int item2)
        {
            Item1=item1;
            Item2=item2;
        }
        public static bool operator >(TupleStringInt lhs, TupleStringInt rhs)
        {
            if (lhs.Item2 > rhs.Item2)
            {
                return lhs.Item1.CompareTo(rhs.Item1) > 0;
            }
            return (lhs.Item2 > rhs.Item2);
        }
        public static bool operator <(TupleStringInt lhs, TupleStringInt rhs)
        {
            if (lhs.Item2 < rhs.Item2)
            {
                return lhs.Item1.CompareTo(rhs.Item1) < 0;
            }
            return lhs.Item2 < rhs.Item2;
        }
        public static bool operator ==(TupleStringInt lhs, TupleStringInt rhs)
        {
            return ((lhs.Item1.CompareTo(rhs.Item1) == 0) && lhs.Item2 == rhs.Item2);
        }
        public static bool operator !=(TupleStringInt lhs, TupleStringInt rhs)
        {
            return ((lhs.Item1.CompareTo(rhs.Item1) != 0) || lhs.Item2 == rhs.Item2);
        }
        public int CompareTo(Object other)
        {
            if (this < (TupleStringInt) other)
            {
                return -1;
            }
            else if (this > (TupleStringInt) other) return 1;
            else return 0;
        }
    }
}