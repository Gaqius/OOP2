using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2_23
{
    /// <summary>
    /// Student class
    /// </summary>
    public class Student
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Month { get; set; }
        public string ExcersiseID { get; set; }

        public Student(string surname, string name, string group, string month, string excersiseId)
        {
            this.Surname=surname;
            this.Name=name;
            this.Group=group;
            this.Month=month;
            this.ExcersiseID=excersiseId;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}