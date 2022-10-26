using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L3.Code
{
    /// <summary>
    /// Excersise class
    /// </summary>
    public class Excersise : IComparable<Excersise>, IEquatable<Excersise>
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ProfNameSurname { get; set; }
        public int TimeLimit { get; set; }
        public Excersise(string iD, string name, string profNameSurname, int timeLimit)
        {
            ID=iD;
            Name=name;
            ProfNameSurname=profNameSurname;
            TimeLimit=timeLimit;
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public int CompareTo(Excersise other)
        {
            return ID.CompareTo(other.ID);
        }

        public bool Equals(Excersise other)
        {
            return ID == other.ID;
        }
    }
}