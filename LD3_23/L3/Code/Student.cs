using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L3.Code
{
    /// <summary>
    /// Student class
    /// </summary>
    public class Student : IComparable<Student>, IEquatable<Student>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Month { get; set; }
        public string ExcersiseID { get; set; }
        public Student(string surname, string name, string group, string month, string excersiseID)
        {
            Surname=surname;
            Name=name;
            Group=group;
            Month=month;
            ExcersiseID=excersiseID;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public int CompareTo(Student other)
        {
            return Surname.CompareTo(other.Surname);
        }
        public bool Equals(Student other)
        {
            return Surname.Equals(other.Surname);
        }
    }
}