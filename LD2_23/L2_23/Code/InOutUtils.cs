using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace L2_23.Code
{
    public class InOutUtils
    {
        /// <summary>
        /// Reads lines from a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static IEnumerable<string> ReadLines (string fileName)
        {
            using (StreamReader reader = File.OpenText(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        /// <summary>
        /// Reads student file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>A student list</returns>
        public static ObjectList ReadStudents(string fileName)
        {
            ObjectList students = new ObjectList();
            foreach (string line in ReadLines(fileName))
            {
                string[] parts = line.Split(';');
                string surname = parts[0];
                string name = parts[1];
                string group = parts[2];
                string month = parts[3];
                string excersiseId = parts[4];
                students.Add(new Student(surname, name, group, month, excersiseId));
            }   
            return students;
        }
        /// <summary>
        /// Reads exercises file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Exercise list</returns>
        public static ObjectList ReadExcersises(string fileName)
        {
            ObjectList excersises = new ObjectList();
            foreach (string line in ReadLines(fileName))
            {
                string[] parts = line.Split(';');
                string iD = parts[0];
                string name = parts[1];
                string profCreds= parts[2];
                int timeLimit = Convert.ToInt32(parts[3]);
                excersises.Add(new Excersise(iD, name, profCreds, timeLimit));
            }
            return excersises;
        }
        /// <summary>
        /// Prints the starting data
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="students"></param>
        public static void PrintData(StreamWriter writer,ObjectList students)
        {
            
            if (students.Count() == 0)
            {
                writer.WriteLine("Tuščia");
                return;
            }
            writer.WriteLine(new string('-', 65));
            writer.WriteLine("| {0,10} | {1,10} | {2,6} | {3,8} | {4,15} |", "Pavardė", "Vardas", "Grupė", "Mėnuo", "Užduoties kodas");
            writer.WriteLine(new string('-', 65));
            foreach (Student e in students)
            {
                writer.WriteLine("| {0,10} | {1,10} | {2,6} | {3,8} | {4,15} |", e.Surname, e.Name, e.Group, e.Month, e.ExcersiseID);
            }
            for (int i = 0; i < students.Count(); i++)
            {
                
            }
            writer.WriteLine(new string('-', 65));
        }
        /// <summary>
        /// Prints assigned students
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="counts"></param>
        public static void PrintAssignedStudentCounts(StreamWriter writer, ObjectList counts)
        {
            if (counts.Count() == 0)
            {
                writer.WriteLine("Tuščia");
                return;
            }
            writer.WriteLine(new string('-', 23));
            writer.WriteLine("| {0,10} | {1,-6} |", "Dėstytojas", "Kiekis");
            writer.WriteLine(new string('-', 23));
            foreach (TupleStringInt e in counts)
            {
                writer.WriteLine("| {0,10} | {1,-6} |", e.Item1, e.Item2);
            }
            writer.WriteLine(new string('-', 23));
        }
        /// <summary>
        /// Pritns exercise table
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="list"></param>
        public static void PrintExerciseTables(StreamWriter writer, Dictionary<string, ObjectList> list)
        {
            foreach (var item in list)
            {
                if (list.Count == 0)
                {
                    writer.WriteLine("Tuščia");
                    return;
                }

                writer.WriteLine(new string('-', 73));
                writer.WriteLine("| {0,12} | {1,21} | {2,10} | {3,14} |", "Užduoties kodas", "Užduoties pavadinimas", "dėstytojas", "skirtas laikas");
                writer.WriteLine(new string('-', 73));
                foreach (Excersise e in item.Value)
                {
                    writer.WriteLine("| {0,15} | {1,21} | {2,10} | {3,14} |", e.ID, e.Name, e.ProfNameSurname, e.TimeLimit);
                }
                writer.WriteLine(new string('-', 73));
            }            
        }
        /// <summary>
        /// Prints filtered exercise table
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="list"></param>
        public static void PrintFilteredExerciseTables(StreamWriter writer, ObjectList list)
        {
            foreach (ObjectList item in list)
            {
                if (list.Count() == 0)
                {
                    writer.WriteLine("Tuščia");
                    return;
                }

                writer.WriteLine(new string('-', 73));
                writer.WriteLine("| {0,12} | {1,21} | {2,10} | {3,14} |", "Užduoties kodas", "Užduoties pavadinimas", "dėstytojas", "skirtas laikas");
                writer.WriteLine(new string('-', 73));
                foreach (Excersise e in item)
                {
                    writer.WriteLine("| {0,15} | {1,21} | {2,10} | {3,14} |", e.ID, e.Name, e.ProfNameSurname, e.TimeLimit);
                }
                writer.WriteLine(new string('-', 73));
            }
        }
    }
}