using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2_23.Code
{
    /// <summary>
    /// Exercises class
    /// </summary>
    public class Excersise
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ProfNameSurname { get; set; }
        public int TimeLimit { get; set; }

        public Excersise(string iD, string name, string profNameSurname, int timeLimit)
        {
            ID=iD;
            this.Name=name;
            this.ProfNameSurname=profNameSurname;
            this.TimeLimit=timeLimit;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}